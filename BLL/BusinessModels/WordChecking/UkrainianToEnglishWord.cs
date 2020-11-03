using BLL.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BusinessModels.WordChecking
{
    public class UkrainianToEnglishWord : AbstractWord
    {
        public override string Question
        {
            get
            {
                return _word.UkrainianTranslation;
            }
        }

        public override bool Check(string answer)
        {
            return String.Compare(answer, _word.EnglshTranslation, true) == 0;
        }

        public UkrainianToEnglishWord(WordDTO word)
            :base(word) { }
    }
}
