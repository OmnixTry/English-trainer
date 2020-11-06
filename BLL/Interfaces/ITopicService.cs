using BLL.DataTransferObjects;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    interface ITopicService
    {
        IEnumerable<TopicDTO> GetTopics();
        IEnumerable<QuestoinDTO> GetEngQuestoins(int topicId);
        IEnumerable<QuestoinDTO> GetUkrQuestoins(int topicId);
        IEnumerable<AnswerDTO> Check(IEnumerable<AnswerDTO> pruposedAnswers);
    }
}