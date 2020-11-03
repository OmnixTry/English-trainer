using BLL.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BLL.Interfaces
{
    /// <summary>
    /// A group of problems
    /// </summary>
    interface IExercise
    {
        /// <summary>
        /// Returns list of questions to answer
        /// </summary>
        IEnumerable<string> Questions { get; }

        /// <summary>
        /// The name of the Exercise    
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Checks all the questions in an exerxise in order.
        /// </summary>
        /// <param name="answers">Array of answers in the same order as questions</param>
        /// <returns>Percentage of correct answers</returns>
        int Check(IEnumerable<string> answers);

        /// <summary>
        /// Creates ExerciseDTO object equivalent to this one
        /// </summary>
        /// <returns>ExerciseDTO that contains all of the problems with their questions but without answers</returns>
        ExerciseDTO ToExerciseDTO();
        
    }
}
