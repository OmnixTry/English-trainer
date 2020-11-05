using BLL.AbstractClasses;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DataTransferObjects
{
    class EnglishToUkrainianWordDTO : BLL.AbstractClasses.AbstractWord
    {
        public override string Question
        { 
            get
            {
                return _englishTranslation;
            }
        }

        internal override string CorrectAnswer
        {
            get
            {
                return _ukrainianTranslation;
            }
        }

        public EnglishToUkrainianWordDTO(WordDTO word)
            : base(word)
        {
            _englishTranslation = word.EnglshTranslation;
            _ukrainianTranslation = word.UkrainianTranslation;
        }

    }
}
