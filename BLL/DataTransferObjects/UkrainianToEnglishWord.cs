using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DataTransferObjects
{
    class UkrainianToEnglishWord :IProblemDTO
    {
        private string _englishTranslation;
        private string _ukrainianTranslation;

        public string Question
        {
            get
            {
                return _ukrainianTranslation;
            }
        }

        string IProblemDTO.CorrectAnswer
        {
            get
            {
                return _englishTranslation;
            }
        }

        public string PruposedAnswer { get; set; }

        public UkrainianToEnglishWord(WordDTO word)
        {
            _englishTranslation = word.EnglshTranslation;
            _ukrainianTranslation = word.UkrainianTranslation;
        }
    }
}
