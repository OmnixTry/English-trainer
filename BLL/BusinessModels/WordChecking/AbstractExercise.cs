using BLL.DataTransferObjects;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BLL.BusinessModels.WordChecking
{
    abstract class AbstractExercise : IExercise
    {
        protected ReadOnlyCollection<IProblem> _problems;

        public IEnumerable<string> Questions
        {
            get
            {
                return _problems.Select(w => w.Question).AsEnumerable();
            }
        }

        public string Title { get; }

        public virtual int Check(IEnumerable<string> answers)
        {
            if (answers == null) 
                throw new ArgumentNullException("answers");
            int count = _problems.Count();
            if (answers.Count() != count)
                throw new ArgumentException(
                    "The number of answers does'nt match the number of questions", "answers");
            string[] answerArray = answers.ToArray();
            int numberOfCorrect = 0;
            
            for (int i = 0; i < count; i++)
            {
                if (_problems[i].Check(answerArray[i]))
                    numberOfCorrect++;
                else
                    ProcessErrors(_problems[i], answerArray[i]);
            }
            return numberOfCorrect * 100 / count;
        }

        //TODO: Finish the method to save info on mistakes
        protected virtual void ProcessErrors(IProblem word, string madeMistake) { }
    }
}
