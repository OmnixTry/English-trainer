using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishTrainer.DAL.Entities
{
    class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Word> Words { get; set; }
        public Topic()
        {
            Words = new List<Word>();
        }
    }
}
