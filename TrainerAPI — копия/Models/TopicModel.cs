using System;
using System.Collections.Generic;
using System.Text;

namespace TrainerAPI.Models
{
    public class TopicModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime LastPlayed { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
    }
}
