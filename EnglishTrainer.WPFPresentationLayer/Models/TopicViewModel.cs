using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishTrainer.WPFPresentationLayer.Models
{
    public class TopicViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime LastPlayed { get; set; }
        public int UserId { get; set; }
        public UserViewModel User { get; set; }
    }
}
