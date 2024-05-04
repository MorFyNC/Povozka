using Povozka.Components.Services;

namespace Povozka.Components.Data
{
    public class Chat
    {
        public Guid Chat_ID { get; set; }
        public List<Message> Messages { get; private set; }

        public Chat()
        {
            Messages = new List<Message>();
            Chat_ID = Guid.NewGuid();
        }

        public void WriteMessage(string message)
        {
            Messages.Add(new Message(message, UserContext.CurrentUser));
            Messages.Sort();
            DataContext.UpdateChats();
        }

        public void ReadMessages()
        {
            foreach (var message in Messages)
            {
                if(message.SenderName != UserContext.CurrentUser.Username)
                {
                    message.isReaded = true;
                }
            }
        }
    }
}
