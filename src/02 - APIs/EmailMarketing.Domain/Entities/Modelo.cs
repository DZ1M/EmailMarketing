using EmailMarketing.Architecture.Core.Domain;
using EmailMarketing.Domain.Enums;

namespace EmailMarketing.Domain.Entities
{
    public class Modelo : Entity
    {
        public string Nome { get; private set; }
        public string Texto { get; private set; }
        public TipoMensagemEnum Tipo { get; private set; }
    }
}
