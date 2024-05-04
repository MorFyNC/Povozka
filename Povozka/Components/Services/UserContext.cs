using Povozka.Components.Data;

namespace Povozka.Components.Services
{
    public static class UserContext
    {
        public static User CurrentUser { get; set; }
        public static Chat OpenedChat { get; set; }
    }
}
