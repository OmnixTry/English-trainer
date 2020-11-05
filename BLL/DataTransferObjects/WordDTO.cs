using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DataTransferObjects
{
    public class WordDTO
    {
        public int Id { get; set; }
        public string Englsh { get; set; }
        public string Ukrainian{ get; set; }
        public TopicDTO Topic { get; set; }
        public ICollection<MistakeDTO> Mistakes { get; set; }

        public WordDTO(TopicDTO topic, string english, string ukrainian)
        {
            if (english == null)
                throw new ArgumentNullException("english");
            if (ukrainian == null)
                throw new ArgumentNullException("ukrainian");
            if (topic == null)
                throw new ArgumentNullException("topic");

            Topic = topic;
            Englsh = english;
            Ukrainian = ukrainian;
        }
    }
}
