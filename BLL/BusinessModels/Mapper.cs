using BLL.DataTransferObjects;
using EnglishTrainer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BusinessModels
{
    static class Mapper
    {
        public static WordDTO MapWordDTO(Word word)
        {
            return new WordDTO(word.Id, word.Topic.Id, word.EnglshTranslation, word.UkrainianTranslation);
        }

        public static TopicDTO MapTopicDTO(Topic topic)
        {
            return new TopicDTO()
            {
                Id = topic.Id,
                Name = topic.Name,
                LastPlayed = topic.LastPlayed
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
    }
}
