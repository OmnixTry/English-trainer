using System;
using System.Collections.Generic;
using System.Text;

namespace TrainerAPI.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        // not null unique
        public string NickName { get; set; }
        public ICollection<MistakeModel> Mistakes { get; set; }
        public ICollection<TopicModel> Topics { get; set; }
        public UserModel()
        {
            Mistakes = new List<MistakeModel>();
            Topics = new List<TopicModel>();
        }
    }
}
