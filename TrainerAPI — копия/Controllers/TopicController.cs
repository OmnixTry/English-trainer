using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DataTransferObjects;
using BLL.Services;
using EnglishTrainer.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using TrainerAPI.Models;
using TrainerAPI.Infrastructure;
using Ninject;
using BLL.Interfaces;

namespace TrainerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicController : Controller
    {
        //TODO 
        //Dependency injection TopicService
        static ITopicService _topicService = new StandardKernel(new BLLBindings()).Get<ITopicService>();
        [HttpGet]
        public IList<TopicModel> Get()
        {
            _topicService = new StandardKernel(new BLLBindings()).Get<ITopicService>();

            IEnumerable<TopicDTO> dtos = _topicService.GetTopics();
            List<TopicModel> models = new List<TopicModel>();
            foreach (TopicDTO dto in dtos)
            {
                models.Add(Mapper.MapTopic(dto));
            }
            return models;
        }

        [HttpPost]
        public IActionResult Post([FromBody] IEnumerable<WordModel> topic, [FromQuery] string topicName, [FromQuery] int userId)
        {
            TopicDTO topicDTO;
            try
            {
                topicDTO = _topicService.AddTopic(Mapper.MapList(topic), topicName, userId);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            TopicModel topicModel = Mapper.MapTopic(topicDTO);
            return Created($"/api/topic/{topicModel.Id}", topicModel);
        }

        [HttpPost]
        public IList<AnswerModel> Check([FromBody] IEnumerable<AnswerModel> words)
        {
            IEnumerable<AnswerDTO> checkedAnswers = _topicService.Check(Mapper.MapList(words));
            return Mapper.MapList(checkedAnswers);
        }

        [Route("{id}/questions/")]
        [HttpGet]
        // topic/id/questionid
        public IEnumerable<QuestionModel> Get(int id, [FromQuery]Models.Language language)
        {
            List<QuestoinDTO> questions;
            switch (language)
            {
                case Models.Language.Ukrainian:
                    questions = _topicService.GetUkrQuestoins(id).ToList();
                    break;
                case Models.Language.English:
                    questions = _topicService.GetEngQuestoins(id).ToList();
                    break;
                default:
                    throw new InvalidOperationException("undefined language");
            }
            
            return Mapper.MapList(questions);
        }

        [HttpGet]
        [Route("{id}/results")]
        public IList<TopicResultModel> Get(int id)
        {
            IEnumerable<TopicResultDTO> dtos = _topicService.GetTopicResults(id);
            return Mapper.MapList(dtos);
        }

    }
}
