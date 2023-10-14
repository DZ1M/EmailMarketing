using EmailMarketing.Architecture.Core.Domain;
using EmailMarketing.Domain.Enums;

namespace EmailMarketing.Domain.Entities
{
    public class Campanha : Entity
    {
        public TipoMensagemEnum TipoMensagem { get; private set; }
        public string Nome { get; private set; }
        public string Titulo { get; private set; }
        public DateTime Data { get; private set; }
        public ICollection<CampanhaPasta> Pastas { get; private set; }
        public Guid IdModelo { get; private set; }
        public Modelo Modelo { get; private set; }
        public ICollection<CampanhaContato> Contatos { get; private set; }
    }
}
