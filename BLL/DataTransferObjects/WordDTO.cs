using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DataTransferObjects
{
    class WordDTO
    {
        public int Id { get; set; }
        public string EnglshTranslation { get; set; }
        public string UkrainianTranslation { get; set; }
        public TopicDTO Topic { get; set; }
        public ICollection<MistakeDTO> Mistakes { get; set; }
    }
}
