using EnglishTrainer.DesctopClient.Delegates;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishTrainer.DesctopClient.Models
{
    public class MistakeViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserViewModel User { get; set; }
        public int WordId { get; set; }
        public WordViewModel Word { get; set; }
        public Language Language { get; set; }
    }
}
