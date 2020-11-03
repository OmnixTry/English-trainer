using BLL.DataTransferObjects;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BLL.BusinessModels.WordChecking
{
    class Topic : AbstractExercise
    {
        public Topic(IEnumerable<AbstractWord> words)
        {
            _problems = words
                .Select(w => (IProblem)w)
                .ToList()
                .AsReadOnly();
        }

        //TODO: Add mistake processing
        protected override void ProcessErrors(IProblem word, string madeMistake)
        {
            
        }
    }
}
