using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Telegram.Bot;

namespace HomeHelper.Bot
{
    public class Bot
    {
        public TelegramBotClient Client { get; private set; }

        public string Name { get; private set; }

        public Bot(string name)
        {
            Name = name;
        }
        
        public async Task InitClient(string tokenKey, string webhookUrl)
        {
            if (Client != null)
            {
                return;
            }

            Client = new TelegramBotClient(tokenKey);
            await Client.SetWebhookAsync(webhookUrl);
        }

        public async Task<bool> CheckStatus()
        {
            return await Client.TestApiAsync();
        }
    }
}
