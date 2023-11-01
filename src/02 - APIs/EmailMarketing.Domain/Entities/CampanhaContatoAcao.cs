using EmailMarketing.Architecture.Core.Domain;
using EmailMarketing.Domain.Enums;

namespace EmailMarketing.Domain.Entities
{
    public class CampanhaContatoAcao : Entity
    {
        protected CampanhaContatoAcao() { }
        public CampanhaContatoAcao(Guid idCampanhaContato, AcaoMensagemEnum acao)
        {
            IdCampanhaContato = idCampanhaContato;
            Acao = acao;
            CriadoEm = DateTime.Now;
        }
        public AcaoMensagemEnum Acao { get; private set; }
        public Guid IdCampanhaContato { get; private set; }
    }
}
