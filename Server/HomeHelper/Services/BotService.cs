using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace HomeHelper.Services
{
    public interface IBotService
    {
        void StatusReport();
    }

    public class BotService : IBotService
    {
        public BotService(IConfiguration config)
        {
            string webhookUrl = config.GetValue<string>("Telegram:WebhookUrl");
            string tokenKey = config.GetValue<string>("Telegram:Token");
            string name = config.GetValue<string>("Telegram:BotName");
            InitBot(name, tokenKey, webhookUrl).ConfigureAwait(false);
        }

        private async Task InitBot(string name, string key, string hookUrl)
        {
            var telebot = new Bot.Bot(name);
            try
            {
                await telebot.InitClient(key, hookUrl);
                bool status = await telebot.CheckStatus();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Telegram bot creation failed. {e.Message}");
            }
        }

        public void StatusReport()
        {
            Console.WriteLine("I'm Ok");
        }
    }
}
