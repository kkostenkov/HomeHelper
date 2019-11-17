using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Telegram.Bot;

namespace HomeHelper.Bot
{
    public class TeleBot
    {
        public TelegramBotClient Client { get; private set; }

        public string Name { get; private set; }

        public TeleBot(string name)
        {
            Name = name;
        }
        
        public async Task InitClient(string tokenKey, string webhookUrl=null)
        {
            if (Client != null)
            {
                return;
            }

            Client = new TelegramBotClient(tokenKey);
            
            if (string.IsNullOrEmpty(webhookUrl))
            {
                //Client.GetUpdatesAsync()
            }
            else
            {
                await Client.SetWebhookAsync(webhookUrl, null, 1);
            }
        }

        public async Task<bool> CheckStatus()
        {
            var me = await Client.GetMeAsync();
            Console.WriteLine(
              $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
            );
            return await Client.TestApiAsync();
        }
    }
}
