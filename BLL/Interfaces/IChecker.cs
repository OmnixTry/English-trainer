using BLL.DataTransferObjects;
using EnglishTrainer.DAL.Entities;
using EnglishTrainer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BLL.Interfaces
{
    public interface IChecker
    {
        /// <summary>
        /// Checks the topic of words
        /// </summary>
        /// <param name="answers">IEnumerable of answers to check for correctness</param>
        /// <returns></returns>
        public IEnumerable<AnswerDTO> CheckTopic(IEnumerable<AnswerDTO> pruposedAnswers, IEnumerable<WordDTO> words);
        TopicResultDTO MakeResult(IEnumerable<AnswerDTO> answers);
    }
}
