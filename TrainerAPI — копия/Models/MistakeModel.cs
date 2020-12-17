namespace TrainerAPI.Models
{
    public class MistakeModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public int WordId { get; set; }
        public WordModel Word { get; set; }
        public Language Language { get; set; }
    }
}
