using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DataTransferObjects
{
    public class EnglishWord : ILanguageWord
    {
        public int WordId { get; }
        public string EnglishText { get; set; }
    }
}
