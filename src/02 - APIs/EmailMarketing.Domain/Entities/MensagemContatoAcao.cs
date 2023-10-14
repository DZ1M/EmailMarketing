using EmailMarketing.Architecture.Core.Domain;
using EmailMarketing.Domain.Enums;

namespace EmailMarketing.Domain.Entities
{
    public class MensagemContatoAcao : Entity
    {
        public AcaoMensagemEnum Acao { get; set; }
        public Guid IdMensagemContato { get; set; }
    }
}
