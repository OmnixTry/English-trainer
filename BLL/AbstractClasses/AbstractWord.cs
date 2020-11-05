using BLL.DataTransferObjects;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace BLL.AbstractClasses
{
    abstract class AbstractWord : ILanguageWord
    {
        public int WordId { get; }
    }
}
