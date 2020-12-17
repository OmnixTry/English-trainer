using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DataTransferObjects;
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
    public class AnswerController : ControllerBase
    {
        static ITopicService _topicService = new StandardKernel(new BLLBindings()).Get<ITopicService>();

        [HttpPost]
        public IList<AnswerModel> Check([FromBody] IEnumerable<AnswerModel> words)
        {
            IEnumerable<AnswerDTO> checkedAnswers = _topicService.Check(Mapper.MapList(words));
            return Mapper.MapList(checkedAnswers);
        }

        [HttpGet]
        public AnswerModel Get()
        {
            return new AnswerModel();
        }
    }
}
