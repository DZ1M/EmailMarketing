using EmailMarketing.Architecture.Core.Domain;
using EmailMarketing.Domain.Enums;

namespace EmailMarketing.Domain.Entities
{
    public class CampanhaContato : Entity
    {
        protected CampanhaContato() { }
        public CampanhaContato(Guid idContato)
        {
            IdContato = idContato;
            Codigo = Guid.NewGuid().ToString("N");
            AddAcao(AcaoMensagemEnum.AguardandoEnvio);
        }
        public void AddAcao(AcaoMensagemEnum acao)
        {
            if(Acoes is null)
            {
                Acoes = new List<CampanhaContatoAcao>();
            }

            Acoes.Add(new CampanhaContatoAcao(Id, acao));
        }
        public Guid IdCampanha { get; private set; }
        public Campanha Campanha { get; private set; }
        public Guid IdContato { get; private set; }
        public Contato Contato { get; private set; }
        public string Codigo { get; private set; }
        public ICollection<CampanhaContatoAcao> Acoes { get; private set; }
    }
}
