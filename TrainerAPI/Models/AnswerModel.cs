namespace TrainerAPI.Models
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
        public Language Language { get; set; }
    }

    public enum Language
    {
        Ukrainian,
        English
    }
}
