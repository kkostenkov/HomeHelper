using Telegram.Bot;
using Telegram.Bot.Types;

namespace HomeHelper.Bot.Commands
{
    public class TestCommand : Command
    {
        public override string Name => "test";

        public override async void Execute(Message message, TeleBot bot)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            await bot.Client.SendTextMessageAsync(chatId, "", replyToMessageId: messageId);
        }
    }
}
