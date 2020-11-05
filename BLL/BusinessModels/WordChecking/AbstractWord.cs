﻿using BLL.DataTransferObjects;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BusinessModels.WordChecking
{
    private abstract class AbstractWord : IProblem
    {
        protected WordDTO _word;

        public abstract string Question { get; }

        public abstract bool Check(string answer);

        public ProblemDTO ToProblemDTO()
        {
            return new ProblemDTO(Question);
        }

        public AbstractWord(WordDTO word)
        {
            _word = word;
        }
    }
}