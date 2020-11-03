using BLL.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    /// <summary>
    /// The smallest unit of work that can be checked
    /// </summary>
    interface IProblem
    {
        /// <summary>
        /// A given Data for a user to solve
        /// </summary>
        string Question { get; }

        /// <summary>
        /// Checks wether the user's answer is correct
        /// </summary>
        /// <param name="answer">the pruposed answer to the problem to check.</param>
        /// <returns>True if the answer is correct</returns>
        bool Check(string answer);

        /// <summary>
        /// Converts problem object to the equivalent ProblemDTO
        /// </summary>
        /// <returns>ProblemDTO with Question field filled and answer field null</returns>
        ProblemDTO ToProblemDTO();
    }
}
