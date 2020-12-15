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
            SaveTopicResult(answers);

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

            // save mistaken words
            SaveMistakenWords(pruposedAnswers);

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

        public void SaveMistakenWords(IEnumerable<AnswerDTO> pruposedAnswers)
        {
            foreach (var wrongWord in pruposedAnswers.Where(a => !a.IsCorrect))
            {
                MistakeDTO mistake = new MistakeDTO()
                {
                    UserId = Database.Words.Get(wrongWord.Id).Topic.UserId,
                    WordId = wrongWord.Id,
                    Language = wrongWord.Language
                };
                Database.Mistakes.Create(Mapper.MapMistake(mistake));
            }
            Database.Save();
        }

        public TopicDTO AddTopic(IEnumerable<WordDTO> words, string topicName, int UserId)
        {
            TopicDTO topic = new TopicDTO();
            topic.Name = topicName;
            topic.UserId = UserId;
            //topic.Words = (ICollection<WordDTO>)words;

            Database.Topics.Create(Mapper.MapTopic(topic));
            Database.Save();

            int newTopicId = Database.Topics.GetAll().Where(t => t.Name == topicName).FirstOrDefault().Id;
            topic.Id = newTopicId;
            foreach (var word in words)
            {
                word.Id = 0;
                word.TopicId = newTopicId;
                //word.Topic = topic;
                Database.Words.Create(Mapper.MapWord(word));
            }
            Database.Save();
            return topic;
        }

        public IEnumerable<TopicResultDTO> GetTopicResults(int topicId)
        {
            IEnumerable<TopicResult> topicResults = Database.TopicResults.Find(r => r.TopicId == topicId).ToList();
            List<TopicResultDTO> topicResultDTOs = new List<TopicResultDTO>();
            foreach (var result in topicResults)
                topicResultDTOs.Add(Mapper.MapTopicResultDTO(result));

            return topicResultDTOs;
        }

        //TODO GEtting results


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

