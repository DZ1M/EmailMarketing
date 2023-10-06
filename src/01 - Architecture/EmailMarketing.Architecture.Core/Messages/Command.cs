using System.Text.Json.Serialization;

namespace EmailMarketing.Architecture.Core.Messages
{
    public abstract class Command
    {
        [JsonIgnore]
        public Guid IdUsuario { get; set; }
        [JsonIgnore]
        public Guid IdEmpresa { get; set; }
        [JsonIgnore]
        public DateTime Timestamp { get; private set; }
        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
