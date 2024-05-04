using Newtonsoft.Json;
using Povozka.Components.Data;
using System;

namespace Povozka.Components.Services
{
    public static class DataContext
    {
        public static List<User> Accounts { get; set; }
        public static List<Chat> Chats { get; set; }
        private static string AccountsPath = "Components//Data//Accounts.txt";
        private static string ChatsPath = "Components//Data//Chats.txt";

        #region Аккаунты
        private static void GetAccounts()
        {
            Accounts = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(AccountsPath));
        }
        public static void AddAccount(User account)
        {
            Accounts.Add(account);
            File.WriteAllText(AccountsPath, JsonConvert.SerializeObject(Accounts));
        }
        public static void DeleteAccount(User account)
        {
            Accounts.Remove(account);
        }

        public static void UpdateUsers()
        {
            File.WriteAllText(AccountsPath, JsonConvert.SerializeObject(Accounts));
        }

        public static User FindUserByGuid(Guid guid)
        {
            GetAccounts();
            foreach (User user in Accounts)
            {
                if (user.ID == guid) return user;
            }
            throw new Exception();
        }
        #endregion


        #region Чаты
        private static void GetChats()
        {
            Chats = JsonConvert.DeserializeObject<List<Chat>>(File.ReadAllText(ChatsPath));
        }
        public static void AddChat(Chat chat)
        {
            Chats.Add(chat);
            File.WriteAllText(ChatsPath, JsonConvert.SerializeObject(Chats));
        }

        public static void DeleteChat(Chat chat)
        {
            Chats.Remove(chat);
            File.WriteAllText(ChatsPath, JsonConvert.SerializeObject(Chats));
        }

        public static Chat FindByGuid(Guid guid)
        {
            foreach (Chat chat in Chats)
            {
                if(chat.Chat_ID == guid) return chat;
            }
            throw new Exception();
        }

        public static void UpdateChats()
        {
            File.WriteAllText(ChatsPath, JsonConvert.SerializeObject(Chats));
        }
        #endregion

        public static void Initialize()
        {
            GetAccounts();
            GetChats();
        }
    }
}
