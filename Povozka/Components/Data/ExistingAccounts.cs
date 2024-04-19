using Newtonsoft.Json;

namespace Povozka.Components.Data
{
    public static class ExistingAccounts
    {
        public static List<User> Accounts { get; set; }
        private static string path = "Components//Data//Accounts.txt";
        public static User CurrentUser { get; set; }

        public static void GetAccounts()
        {
            Accounts = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(path));
        }

        public static void AddAccount(User account)
        {
            Accounts.Add(account);
            File.WriteAllText(path, JsonConvert.SerializeObject(Accounts));
        }
    }
}
