﻿using EnglishTrainer.WPFPresentationLayer.Delegates;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishTrainer.WPFPresentationLayer.Models
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public string Question { get; set; }
        public Language Language { get; set; }
        public Language TranslateIntoLanguage { get; set; }
    }
}
