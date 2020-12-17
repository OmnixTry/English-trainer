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
    public class ResultController : ControllerBase
    {
        static ITopicService _topicService = new StandardKernel(new BLLBindings()).Get<ITopicService>();

        [HttpGet]
        [Route("{id}")]
        public IList<TopicResultModel> Get(int id)
        {
            IEnumerable<TopicResultDTO> dtos = _topicService.GetTopicResults(id);
            return Mapper.MapList(dtos);
        }
    }
}
