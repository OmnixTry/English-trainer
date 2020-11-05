using BLL.DataTransferObjects;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace BLL.AbstractClasses
{
    abstract class AbstractWord : IProblemDTO
    {
        public string Question { get; }

        public string PruposedAnswer { get; set; }

        string IProblemDTO.CorrectAnswer { get; }

        public AbstractWord(string question, string answer)
        {
            Question = question;
            CorrectAnswer


        }
    }
}
