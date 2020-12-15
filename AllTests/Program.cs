using System;
using System.Collections.Generic;
using EnglishTrainer.DAL.Entities;
using EnglishTrainer.DAL.Interfaces;
using EnglishTrainer.DAL.Repositories;
using BLL.Interfaces;
using BLL.Services;
using BLL.DataTransferObjects;
using BLL.BusinessModels;
using Newtonsoft.Json.Serialization;
using System.Linq;
using Ninject;
using BLL.Infrastructure;
using EnglishTrainer.WPFPresentationLayer.Infrastructure;

namespace AllTests
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new DALBindings("DefaultConnection"), new BLLBindings());
            // IVocabularyUnitOfWork unitOfWork = new EFVocabularyUnitOfWork("DefaultConnection");
            IVocabularyUnitOfWork unitOfWork = kernel.Get<IVocabularyUnitOfWork>();

            WordRepository wordRepo = (WordRepository)unitOfWork.Words;
            TopicRepository topicRepository = (TopicRepository)unitOfWork.Topics;
            
            /*
            User user = new User() { NickName = "Test" };

            Word word1 = new Word() { EnglshTranslation = "Color", UkrainianTranslation = "Колір" };
            Word word2 = new Word() { EnglshTranslation = "House", UkrainianTranslation = "Будинок" };
            Word word3 = new Word() { EnglshTranslation = "Door", UkrainianTranslation = "Двері" };
            Topic topic = new Topic { Name = "Starter2", Words = new List<Word>() { word1, word2, word3}, User = user };
            word1.Topic = topic;
            word2.Topic = topic;
            word3.Topic = topic;
            wordRepo.Create(word1);
            wordRepo.Create(word2);
            wordRepo.Create(word3);
            

            topicRepository.Create(topic);
            unitOfWork.Save();
            */

            foreach (Word word in wordRepo.GetAll())
            {
                Console.WriteLine("{0}, {1}, {2}, {3}", word.Id, word.EnglshTranslation, word.UkrainianTranslation, word.Topic.Id);
            }


            //ITopicService topicService = new TopicService(unitOfWork, new Checker());
            ITopicService topicService = kernel.Get<ITopicService>();

            foreach (TopicDTO item in topicService.GetTopics())
            {
                Console.WriteLine("{0}, {1}\n", item.Id, item.Name);
            }

            Console.WriteLine("get topic with id 1\n" +
                "{0}\n", topicService.GetEngQuestoins(1).First().Queston);
            Console.WriteLine("get topic with id 1\n" +
                "{0}\n", topicService.GetUkrQuestoins(1).First().Queston);

            var res = topicService.Check(new List<AnswerDTO>() { 
                new AnswerDTO() { Id = 1, Answer = "Color", Language = Language.English, TopicId = 1 },
                new AnswerDTO() { Id = 2, Answer = "House", Language = Language.English, TopicId = 1 },
                new AnswerDTO() { Id = 3 , Answer = "e", Language = Language.English, TopicId = 1 },
            });

            foreach (var item in res)
            {
                Console.WriteLine("{0} {1}", item.IsCorrect, item.Answer);
            }

            List<WordDTO> wordsToInsert = new List<WordDTO>()
            {
                new WordDTO("Book", "Книга"),
                new WordDTO("Thread", "Нитка"),
                new WordDTO("Computer", "Комп'ютер"),
                new WordDTO("Paper", "Папір")
            };
            topicService.AddTopic(wordsToInsert, "starter3", 1);
        }
    }
}
