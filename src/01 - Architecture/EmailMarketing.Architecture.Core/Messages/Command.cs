using System.Text.Json.Serialization;

namespace EmailMarketing.Architecture.Core.Messages
{
    public abstract class Command
    {
        [JsonIgnore]
        public Guid IdUser { get; set; }
        [JsonIgnore]
        public Guid IdEnterprise { get; set; }
        [JsonIgnore]
        public DateTime Timestamp { get; private set; }
        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
