using HomeHelper.Bot.Commands;
using HomeHelper.Controllers;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace HomeHelper.Services
{
    public interface IBotService
    {
        Task<bool> CheckStatus();
        void Process(Update update);
    }

    public class BotService : IBotService
    {
        private Bot.TeleBot bot;

        public BotService(IConfiguration config)
        {
            string url = config.GetValue<string>("Telegram:WebhookUrl");
            string webhookUrl = $"{url}/api/bot/{BotController.WEBHOOK_ROUTE}";

            string tokenKey = config.GetValue<string>("Telegram:Token");
            string name = config.GetValue<string>("Telegram:BotName");
            InitBot(name, tokenKey, null).ConfigureAwait(false);
        }

        private async Task InitBot(string name, string key, string hookUrl)
        {
            bot = new Bot.TeleBot(name);
            try
            {
                await bot.InitClient(key, hookUrl);
                
            }
            catch (Exception e)
            {
                Console.WriteLine($"Telegram bot creation failed. {e.Message}");
            }
        }

        public async Task<bool> CheckStatus()
        {
            var statusOk = await bot.CheckStatus();
            if (statusOk)
            {
                Console.WriteLine("Bot is Ok");
            }
            else
            {
                Console.WriteLine("Bot status check failed");
            }
            return statusOk;
        }

        public void Process(Update update)
        {
            var msg = update.Message;
            new TestCommand().Execute(msg, bot);
        }
    }
}
