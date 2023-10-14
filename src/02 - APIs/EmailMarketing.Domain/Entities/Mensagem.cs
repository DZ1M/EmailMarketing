using EmailMarketing.Architecture.Core.Domain;
using EmailMarketing.Domain.Enums;

namespace EmailMarketing.Domain.Entities
{
    public class Mensagem : Entity
    {
        public Mensagem() { }
        public string Nome { get; private set; }
        public TipoMensagemEnum TipoMensagem { get; private set; }
        public Guid IdModelo { get; private set; }
        public Guid IdCampanha { get; private set; }
        public ICollection<MensagemContato> Contatos { get; private set; }

    }
}
