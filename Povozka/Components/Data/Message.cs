using System.Text.Json.Serialization;

namespace Povozka.Components.Data
{
    public class Message : IComparable<Message>
    {
        public string Text { get; set; }
        public DateTime time { get; set; }
        public string SenderName { get; set; }
        public bool isReaded { get; set; }
        internal Message(string text, User sender)
        {
            Text = text;
            SenderName = sender.Username;
            time = DateTime.Now;
        }

        [JsonConstructor]
        public Message(string Text, DateTime time, string SenderName)
        {
            this.Text = Text;
            this.SenderName = SenderName;
            this.time = time;
        }

        public int CompareTo(Message? message)
        {
                return this.time.CompareTo(message.time);
        }
    }
}
