using BLL.DataTransferObjects;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BusinessModels.WordChecking
{
    public abstract class AbstractWord : IProblem
    {
        protected WordDTO _word;

        public abstract string Question { get; }

        public abstract bool Check(string answer);
    }
}
