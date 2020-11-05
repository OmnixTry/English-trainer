using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DataTransferObjects
{
    public class WordDTO
    {
        public int Id { get; set; }
        public EnglishWord Englsh { get; set; }
        public UkrainianWord Ukrainian{ get; set; }
        public TopicDTO Topic { get; set; }
        public ICollection<MistakeDTO> Mistakes { get; set; }

        public WordDTO(EnglishWord english, UkrainianWord ukrainian)
        {
            if (english == null)
                throw new ArgumentNullException("english");
            if (ukrainian == null)
                throw new ArgumentNullException("ukrainian");
            if (english.WordId != ukrainian.WordId)
                throw new ArgumentException("Inconsistency in word ID's");

            Englsh = english;
            Ukrainian = ukrainian;
        }
    }
}
