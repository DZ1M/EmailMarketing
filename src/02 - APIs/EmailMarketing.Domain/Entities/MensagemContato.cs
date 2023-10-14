using EmailMarketing.Architecture.Core.Domain;

namespace EmailMarketing.Domain.Entities
{
    public class MensagemContato : Entity
    {
        public Guid IdMensagem { get; set; }
        public Guid IdContato { get; set; }
        public string Codigo { get; set; }
        public ICollection<MensagemContatoAcao> Acoes { get; set; }
    }
}
