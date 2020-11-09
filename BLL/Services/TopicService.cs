using BLL.BusinessModels;
using BLL.DataTransferObjects;
using BLL.Interfaces;
using EnglishTrainer.DAL.Entities;
using EnglishTrainer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public class TopicService : ITopicService
    {
        private IVocabularyUnitOfWork Database { get; set; }
        private IChecker Checker { get; set; }

        public TopicService(IVocabularyUnitOfWork uow, IChecker checker)
        {
            Database = uow;
            Checker = checker;
        }

        public IEnumerable<AnswerDTO> Check(IEnumerable<AnswerDTO> pruposedAnswers)
        {
            // find and generate correct answers
            List<WordDTO> correctAnswers = new List<WordDTO>();
            foreach (var answer in pruposedAnswers)
            {
                WordDTO currentWord = Mapper.MapWordDTO(Database.Words.Get(answer.Id));
                correctAnswers.Add(currentWord);
            }

            // Check the answers
            IEnumerable<AnswerDTO> answers = Checker.CheckTopic(pruposedAnswers, correctAnswers);

            //TODO: save results

            return answers;
        }
        
        public IEnumerable<QuestoinDTO> GetEngQuestoins(int topicId)
        {
            return getTopicOfQuestions(topicId, Language.English);
        }

        public IEnumerable<TopicDTO> GetTopics()
        {
            foreach (var topic in Database.Topics.GetAll())
            {
                yield return Mapper.MapTopicDTO(topic);
            }
        }

        public IEnumerable<QuestoinDTO> GetUkrQuestoins(int topicId)
        {
            return getTopicOfQuestions(topicId, Language.Ukrainian);
        }

        public bool SaveTopicResult(IEnumerable<AnswerDTO> pruposedAnswers)
        {
            if (pruposedAnswers == null)
                throw new ArgumentNullException();
            if (pruposedAnswers.GroupBy(x => x.TopicId).Count() != 1)
                return false;
            else if (pruposedAnswers.GroupBy(x => x.Language).Count() != 1)
                return false;

            TopicResultDTO topicResultDTO = new TopicResultDTO();
            topicResultDTO.CorrectPercentage = pruposedAnswers.Where(a => a.IsCorrect == true).Count() * 100 / pruposedAnswers.Count();
            topicResultDTO.CompletionDate = DateTime.Now;
            topicResultDTO.Language = pruposedAnswers.First().Language;
            topicResultDTO.TopicId = pruposedAnswers.First().TopicId;

            Database.TopicResults.Create(Mapper.MapTopicResult(topicResultDTO));
            Database.Save();
            return true;
        }

        //
        // private methods
        //

        private IEnumerable<QuestoinDTO> getTopicOfQuestions(int topicId, Language language)
        {
            IEnumerable<WordDTO> words = GetWords(topicId);
            foreach (var word in words)
            {
                yield return GenerateQuestion(word, language);
            }
        }
        
        private QuestoinDTO GenerateQuestion(WordDTO word, Language language)
        {
            QuestoinDTO question = new QuestoinDTO()
            {
                Id = word.Id,
                TopicId = word.TopicId,
                Language = language
            };
            switch (language)
            {
                case Language.Ukrainian:
                    question.Queston = word.Ukrainian;
                    question.TranslateIntoLanguage = Language.English;
                    break;
                case Language.English:
                    question.Queston = word.Englsh;
                    question.TranslateIntoLanguage = Language.Ukrainian;
                    break;
            }
            return question;
        }

        private IEnumerable<WordDTO> GetWords(int topicId)
        {
            IEnumerable<Word> words = Database.Topics.Get(topicId).Words;
            foreach (var word in words)
            {
                yield return Mapper.MapWordDTO(word);
            }            
        }
    }
}

