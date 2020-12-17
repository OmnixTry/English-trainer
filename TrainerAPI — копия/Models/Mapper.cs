using BLL.DataTransferObjects;
using System;
using System.Collections;
using System.Collections.Generic;

namespace TrainerAPI.Models
{
    static class Mapper
    {
        public static List<AnswerDTO> MapList(IEnumerable<AnswerModel> models)
        {
            List<AnswerDTO> dtos = new List<AnswerDTO>();
            foreach (AnswerModel model in models)
            {
                dtos.Add(MapAnswerDTO(model));
            }
            return dtos;
        }

        public static List<AnswerModel> MapList(IEnumerable<AnswerDTO> models)
        {
            List<AnswerModel> dtos = new List<AnswerModel>();
            foreach (AnswerDTO model in models)
            {
                dtos.Add(MapAnswer(model));
            }
            return dtos;
        }

        internal static IList<TopicResultModel> MapList(IEnumerable<TopicResultDTO> results)
        {
            List<TopicResultModel> dtos = new List<TopicResultModel>();
            foreach (TopicResultDTO model in results)
            {
                dtos.Add(MapTopicResult(model));
            }
            return dtos;
        }

        public static List<WordDTO> MapList(IEnumerable<WordModel> models)
        {
            List<WordDTO> dtos = new List<WordDTO>();
            foreach (WordModel model in models)
            {
                dtos.Add(MapWordDTO(model));
            }
            return dtos;
        }

        public static List<QuestionModel> MapList(IEnumerable<QuestoinDTO> models)
        {
            List<QuestionModel> dtos = new List<QuestionModel>();
            foreach (QuestoinDTO model in models)
            {
                dtos.Add(mapQuestion(model));
            }
            return dtos;
        }

        public static WordDTO MapWordDTO(WordModel word)
        {
            WordDTO newWord = new WordDTO(word.Englsh, word.Ukrainian, word.Id);
            // WordDTO newWord = new WordDTO(word.Englsh, word.Ukrainian, word.Id, word.Topic.Id);
            //newWord.Topic = MapTopicDTO(word.Topic);
            return newWord;
        }

        public static TopicDTO MapTopicDTO(TopicModel topic)
        {
            return new TopicDTO()
            {
                Id = topic.Id,
                Name = topic.Name,
                LastPlayed = topic.LastPlayed,
                UserId = topic.UserId,
            };
        }

        public static TopicModel MapTopic(TopicDTO topic)
        {
            return new TopicModel()
            {
                Id = topic.Id,
                Name = topic.Name,
                UserId = topic.UserId,
                LastPlayed = topic.LastPlayed
            };
        }

        public static WordModel MapWord(WordDTO word)
        {
            return new WordModel()
            {
                Id = word.Id,
                TopicId = word.TopicId,
                Englsh = word.Englsh,
                Ukrainian = word.Ukrainian,
                Topic = MapTopic(word.Topic)
            };
        }

        internal static QuestoinDTO MapQuestionDTO(QuestionModel question)
        {
            return new QuestoinDTO()
            {
                Id = question.Id,
                Language = (BLL.DataTransferObjects.Language)question.Language,
                Queston = question.Question,
                TopicId = question.TopicId,
                TranslateIntoLanguage = (BLL.DataTransferObjects.Language)question.TranslateIntoLanguage
            };
        }

        internal static AnswerModel MapAnswer(AnswerDTO answer)
        {
            return new AnswerModel()
            {
                Id = answer.Id,
                Answer = answer.Answer,
                Language = (Language)answer.Language,
                TopicId = answer.TopicId,
                IsCorrect = answer.IsCorrect                
            };
        }

        internal static AnswerDTO MapAnswerDTO(AnswerModel answer)
        {
            return new AnswerDTO()
            {
                Id = answer.Id,
                Answer = answer.Answer,
                Language = (BLL.DataTransferObjects.Language)answer.Language,
                TopicId = answer.TopicId,
                IsCorrect = answer.IsCorrect
            };
        }

        public static TopicResultDTO MapTopicResultDTO(TopicResultModel result)
        {
            return new TopicResultDTO()
            {
                Id = result.Id,
                TopicId = result.Id,
                CompletionDate = result.CompletionDate,
                CorrectPercentage = result.CorrectPercentage,
                Language = (BLL.DataTransferObjects.Language)Enum.Parse(typeof(BLL.DataTransferObjects.Language), result.Language.ToString())
            };
        }

        public static TopicResultModel MapTopicResult(TopicResultDTO result)
        {
            return new TopicResultModel()
            {
                Id = result.Id,
                TopicId = result.TopicId,
                CorrectPercentage = result.CorrectPercentage,
                CompletionDate = result.CompletionDate,
                Language = (Language)Enum.Parse(typeof(Language), result.Language.ToString())
            };
        }

        public static MistakeModel MapMistake(MistakeDTO mistake)
        {
            return new MistakeModel()
            {
                Id = mistake.Id,
                UserId = mistake.UserId,
                WordId = mistake.WordId,
                Language = (Language)Enum.Parse(typeof(Language), mistake.Language.ToString())
            };
        }

        public static QuestionModel mapQuestion(QuestoinDTO question)
        {
            return new QuestionModel()
            {
                Id = question.Id,
                Language = (Language)question.Language,
                Question = question.Queston,
                TopicId = question.TopicId,
                TranslateIntoLanguage = (Language)question.TranslateIntoLanguage
            };
        }
    }
}
