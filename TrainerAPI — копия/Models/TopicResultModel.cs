using System;

namespace TrainerAPI.Models
{
    public class TopicResultModel
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public int CorrectPercentage { get; set; }
        public DateTime CompletionDate { get; set; }
        public Language Language { get; set; }
    }
}
