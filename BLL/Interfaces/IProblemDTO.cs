using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    interface IProblemDTO
    {
        public string Question { get; }
        internal string CorrectAnswer { get; }
        public string PruposedAnswer { get; set; }
    }
}
