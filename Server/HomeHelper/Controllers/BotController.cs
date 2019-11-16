using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeHelper.Services;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeHelper.Controllers
{
    [Route("api/[controller]")]
    public class BotController : Controller
    {
        IBotService botService;
        public BotController(IBotService botService)
        {
            this.botService = botService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            botService.StatusReport();
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"value {id}";
        }

        [Route("message_update")]
        public OkResult Update([FromBody]Update update)
        {
            var message = update.Message;
            

            return Ok();
        }
    }
}
