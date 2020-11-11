using BLL.DataTransferObjects;
using EnglishTrainer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace EnglishTrainer.WPFPresentationLayer.Models
{
    static class Mapper
    {
        public static WordDTO MapWordDTO(WordViewModel word)
        {
            WordDTO newWord = new WordDTO(word.Englsh, word.Ukrainian, word.Id, word.Topic.Id);
            newWord.Topic = MapTopicDTO(word.Topic);
            return newWord;
        }

        public static TopicDTO MapTopicDTO(TopicViewModel topic)
        {
            return new TopicDTO()
            {
                Id = topic.Id,
                Name = topic.Name,
                LastPlayed = topic.LastPlayed,
                UserId = topic.UserId,
            };
        }

        public static TopicViewModel MapTopic(TopicDTO topic)
        {
            return new TopicViewModel()
            {
                Id = topic.Id,
                Name = topic.Name,
                UserId = topic.UserId,
                LastPlayed = topic.LastPlayed
            };
        }

        public static WordViewModel MapWord(WordDTO word)
        {
            return new WordViewModel(word.Englsh, word.Ukrainian, word.Id, word.TopicId )
            {
                // Id = word.Id,
                // TopicId = word.TopicId,
                // Englsh = word.Englsh,
                // Ukrainian = word.Ukrainian,
 //               Topic = MapTopic(word.Topic)
            };
        }

        public static TopicResultDTO MapTopicResultDTO(TopicResultViewModel result)
        {
            return new TopicResultDTO()
            {
                Id = result.Id,
                TopicId = result.Id,
                CompletionDate = result.CompletionDate,
                CorrectPercentage = result.CorrectPercentage,
                Language = (Language)Enum.Parse(typeof(Language), result.Language.ToString())
            };
        }

        public static TopicResultViewModel MapTopicResult(TopicResultDTO result)
        {
            return new TopicResultViewModel()
            {
                Id = result.Id,
                TopicId = result.TopicId,
                CorrectPercentage = result.CorrectPercentage,
                CompletionDate = result.CompletionDate,
                Language = (Delegates.Language)Enum.Parse(typeof(Language), result.Language.ToString())
            };
        }

        public static MistakeViewModel MapMistake(MistakeDTO mistake)
        {
            return new MistakeViewModel()
            {
                Id = mistake.Id,
                UserId = mistake.UserId,
                WordId = mistake.WordId,
                Language = (Delegates.Language)Enum.Parse(typeof(Language), mistake.Language.ToString())
            };
        }
    }
}
