using BLL.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BusinessModels.WordChecking
{
    public class EnglishToUkrainianWord : AbstractWord
    {
        public override string Question
        {
            get
            {
                return _word.EnglshTranslation;
            }
        }

        public override bool Check(string answer)
        {
            return String.Compare(answer, _word.UkrainianTranslation, true) == 0;
        }

        public EnglishToUkrainianWord(WordDTO word)
            : base(word) { }
    }
}
