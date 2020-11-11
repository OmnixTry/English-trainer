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
        public int TopicId { get; set; }
        public TopicDTO Topic { get; set; }

        public WordDTO(string english, string ukrainian, int id = 0, int topicId = 0)
        {
            if (english == null)
                throw new ArgumentNullException("english");
            if (ukrainian == null)
                throw new ArgumentNullException("ukrainian");

            Id = id;
            TopicId = topicId;
            Englsh = english;
            Ukrainian = ukrainian;
        }
    }
}
