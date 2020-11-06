using BLL.DataTransferObjects;
using BLL.Interfaces;
using EnglishTrainer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    class TopicService : ITopicService
    {
        private IVocabularyUnitOfWork Database { get; set; }

        public TopicService(IVocabularyUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<AnswerDTO> Check(IEnumerable<AnswerDTO> pruposedAnswers)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<QuestoinDTO> GetEngQuestoins(int topicId)
        {
            
            
        }

        public IEnumerable<TopicDTO> GetTopics()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<QuestoinDTO> GetUkrQuestoins(int topicId)
        {
            throw new NotImplementedException();
        }

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

            return Database.Topics.Get(topicId).Words;
        }
    }
}
