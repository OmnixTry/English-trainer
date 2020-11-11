using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DataTransferObjects
{
    public class TopicResultDTO
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public int CorrectPercentage { get; set; }
        public DateTime CompletionDate { get; set; }
        public Language Language { get; set; }
        public TopicResultDTO()
        {
        }
    }
}
