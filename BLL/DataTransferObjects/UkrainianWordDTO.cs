using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DataTransferObjects
{
    public class UkrainianWordDTO : ILanguageWord
    {
        public int WordId { get; }
        public string UkrainianText { get; set; }
    }
}
