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

        public WordDTO(int id, int topicId, string english, string ukrainian)
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
