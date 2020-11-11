using EnglishTrainer.WPFPresentationLayer.Delegates;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishTrainer.WPFPresentationLayer.Models
{
    public class QuestoinViewModel
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public string Queston { get; set; }
        public Language Language { get; set; }
        public Language TranslateIntoLanguage { get; set; }
    }
}
