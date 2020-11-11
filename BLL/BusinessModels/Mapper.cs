using BLL.DataTransferObjects;
using EnglishTrainer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace BLL.BusinessModels
{
    static class Mapper
    {
        public static WordDTO MapWordDTO(Word word)
        {
            WordDTO newWord = new WordDTO(word.EnglshTranslation, word.UkrainianTranslation, word.Id, word.Topic.Id);
            newWord.Topic = MapTopicDTO(word.Topic);
            return newWord;
        }

        public static TopicDTO MapTopicDTO(Topic topic)
        {
            return new TopicDTO()
            {
                Id = topic.Id,
                Name = topic.Name,
                LastPlayed = topic.LastPlayed,
                UserId = topic.UserId,
            };
        }

        public static Topic MapTopic(TopicDTO topic)
        {

            return new Topic()
            {
                Id = topic.Id,
                Name = topic.Name,
                UserId = topic.UserId,
                LastPlayed = topic.LastPlayed
            };
        }

        public static Word MapWord(WordDTO word)
        {
            return new Word()
            {
                Id = word.Id,
                TopicId = word.TopicId,
                EnglshTranslation = word.Englsh,
                UkrainianTranslation = word.Ukrainian,
 //               Topic = MapTopic(word.Topic)
            };
        }

        public static TopicResultDTO MapTopicResultDTO(TopicResult result)
        {
            return new TopicResultDTO()
            {
                Id = result.Id,
                TopicId = result.Id,
                CompletionDate = result.CompletionDate,
                CorrectPercentage = result.CorrectPercentage,
                Language = (Language)Enum.Parse(typeof(Language), result.Language)
            };
        }

        public static TopicResult MapTopicResult(TopicResultDTO result)
        {
            return new TopicResult()
            {
                Id = result.Id,
                TopicId = result.TopicId,
                CorrectPercentage = result.CorrectPercentage,
                CompletionDate = result.CompletionDate,
                Language = result.Language.ToString()
            };
        }

        public static Mistake MapMistake(MistakeDTO mistake)
        {
            return new Mistake()
            {
                Id = mistake.Id,
                UserId = mistake.UserId,
                WordId = mistake.WordId,
                Language = mistake.Language.ToString()
            };
        }
    }
}
