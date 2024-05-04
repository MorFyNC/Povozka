using Povozka.Components.Services;
using System.Net;

namespace Povozka.Components.Data
{
    public class User
    {
        public string Username { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Guid ID { get; set; }
        public Dictionary<Guid, Guid> Chats { get; set; }

        public User(string username, string login, string pass)
        {
            ID = Guid.NewGuid();
            Username = username;
            Login = login;
            Password = pass;
            Chats = new Dictionary<Guid, Guid>();
        }

        public void EnterChat(User sender)
        {
            if(Chats.ContainsKey(sender.ID))
            {
                UserContext.OpenedChat = DataContext.FindByGuid(Chats[sender.ID]);
            }
            else
            {
                Chat chat = new Chat();
                Chats.Add(sender.ID, chat.Chat_ID);
                sender.Chats.Add(ID, chat.Chat_ID);
                DataContext.UpdateUsers();
                DataContext.AddChat(chat);
                EnterChat(sender);
            }
        }
    }
}
