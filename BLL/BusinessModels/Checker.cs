using BLL.DataTransferObjects;
using BLL.Interfaces;
using EnglishTrainer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.BusinessModels
{
    class Checker : IChecker
    {
        /// <summary>
        /// Checks the list of answers according to the correct words
        /// </summary>
        /// <param name="pruposedAnswers">words to check</param>
        /// <param name="words">Correct words to compare to pruposed answers</param>
        /// <returns></returns>
        public IEnumerable<AnswerDTO> CheckTopic(IEnumerable<AnswerDTO> pruposedAnswers, IEnumerable<WordDTO> words)
        {
            List<AnswerDTO> results = new List<AnswerDTO>();
            foreach (AnswerDTO answer in pruposedAnswers)
            {
                AnswerDTO result = GetCorrectAnswers(answer);
                try
                {
                    if (compareAnswers(answer.Answer, result.Answer))
                        result.IsCorrect = true;
                    else
                        result.IsCorrect = false;
                }
                catch (NullReferenceException)
                {

                    throw new ArgumentException("Words doesn't contain all nexesary elements to check all the pruposedAnswers");
                }
                
                
                results.Add(result);
            }

            return results;

            AnswerDTO GetCorrectAnswers(AnswerDTO answer)
            {
                AnswerDTO result = words
                    .Where(r => r.Id == answer.Id)
                    .Select(a => new AnswerDTO()
                    {
                        Id = a.Id,
                        Answer = answer.Language == Language.English ? a.Englsh : a.Ukrainian,                        
                    }).FirstOrDefault();

                return result;
            }

            bool compareAnswers(string a1, string a2)
            {
                return String.Compare(a1, a2, true) == 0;
            }
        }

        /// <summary>
        /// Creates TopicResult from list of answers
        /// </summary>
        /// <param name="answers"></param>
        /// <returns></returns>
        public TopicResultDTO MakeResult(IEnumerable<AnswerDTO> answers)
        {
            if (answers.GroupBy(a => a.TopicId).Count() != 1)
                throw new ArgumentException("Answers don't belong to the same topic.");

            TopicResultDTO topicResult = new TopicResultDTO();
            topicResult.CompletionDate = DateTime.Now;
            
            int all = answers.Count();
            topicResult.CorrectPercentage = answers.Where(a => a.IsCorrect == true).Count() * 100 / all;

            topicResult.TopicId = answers.FirstOrDefault().TopicId;

            return topicResult;
        }
    }
}
