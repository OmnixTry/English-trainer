namespace TrainerAPI.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public string Question { get; set; }
        public Language Language { get; set; }
        public Language TranslateIntoLanguage { get; set; }
    }
}
