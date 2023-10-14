using EmailMarketing.Architecture.Core.Domain;
using EmailMarketing.Domain.Enums;

namespace EmailMarketing.Domain.Entities
{
    public class CampanhaContatoAcao : Entity
    {
        public AcaoMensagemEnum Acao { get; set; }
        public Guid IdCampanhaContato { get; set; }
    }
}
