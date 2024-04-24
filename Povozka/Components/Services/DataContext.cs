using Newtonsoft.Json;
using Povozka.Components.Data;

namespace Povozka.Components.Services
{
    public static class DataContext
    {
        public static List<User> Accounts { get; set; }
        private static string path = "Components//Data//Accounts.txt";

        public static void GetAccounts()
        {
            Accounts = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(path));
        }

        public static void AddAccount(User account)
        {
            Accounts.Add(account);
            File.WriteAllText(path, JsonConvert.SerializeObject(Accounts));
        }

        public static void DeleteAccount(User account)
        {
            Accounts.Remove(account);
        }
    }
}
