using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishTrainer.DesctopClient.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        // not null unique
        public string NickName { get; set; }
        public ICollection<MistakeViewModel> Mistakes { get; set; }
        public ICollection<TopicViewModel> Topics { get; set; }
        public UserViewModel()
        {
            Mistakes = new List<MistakeViewModel>();
            Topics = new List<TopicViewModel>();
        }
    }
}
