using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishTrainer.DAL.Entities
{
    class Word
    {
        public int Id { get; set; }
        public string EnglshTranslation { get; set; }
        public string UkrainianTranslation { get; set; }
        public Topic Topic { get; set; }
        public ICollection<Mistake> Mistakes { get; set; }
    }
}
