using System.Collections.Generic;
using HomeHelper.Services;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;


namespace HomeHelper.Controllers
{
    [Route("api/[controller]")]
    public class BotController : Controller
    {
        public const string WEBHOOK_ROUTE = "message_update";

        IBotService botService;
        public BotController(IBotService botService)
        {
            this.botService = botService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"value {id}";
        }

        [Route(WEBHOOK_ROUTE)]
        public OkResult Update([FromBody]Update update)
        {
            var message = update.Message;
            botService.Process(update);

            return Ok();
        }

        [Route("status")]        
        public string Status()
        {
            var isOk = botService.CheckStatus().GetAwaiter().GetResult();
            var res = isOk ? "Ok" : "failed status check";
            return $"bot {res}";
        }

        
    }
}
