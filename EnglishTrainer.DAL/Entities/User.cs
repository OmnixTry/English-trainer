using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishTrainer.DAL.Entities
{
    class User
    {
        public int Id { get; set; }
        // not null unique
        public string NickName { get; set; }
        public ICollection<Mistake> Mistakes { get; set; }
    }
}
