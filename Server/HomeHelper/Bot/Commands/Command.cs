using Telegram.Bot;
using Telegram.Bot.Types;

namespace HomeHelper.Bot.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }

        public abstract void Execute(Message message, TeleBot bot);
    }
}
