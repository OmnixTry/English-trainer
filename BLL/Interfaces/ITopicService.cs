using BLL.DataTransferObjects;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface ITopicService
    {
        IEnumerable<TopicDTO> GetTopics();
        IEnumerable<QuestoinDTO> GetEngQuestoins(int topicId);
        IEnumerable<QuestoinDTO> GetUkrQuestoins(int topicId);
        IEnumerable<AnswerDTO> Check(IEnumerable<AnswerDTO> pruposedAnswers);
        bool SaveTopicResult(IEnumerable<AnswerDTO> pruposedAnswers);
        void AddTopic(IEnumerable<WordDTO> words, string topicName, int UserId);
    }
}