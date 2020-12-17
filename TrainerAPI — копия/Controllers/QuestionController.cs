using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ninject;
using TrainerAPI.Infrastructure;
using TrainerAPI.Models;

namespace TrainerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        ITopicService _topicService;
        public QuestionController()
        {
            _topicService = new StandardKernel(new BLLBindings()).Get<ITopicService>();
        }
        [Route("English/{id}")]
        [HttpGet]
        // topic/id/questionid
        public IEnumerable<QuestionModel> Get(int id)
        {
            var questions = _topicService.GetEngQuestoins(id).ToList();
            return Mapper.MapList(questions);
        }
    }
}
