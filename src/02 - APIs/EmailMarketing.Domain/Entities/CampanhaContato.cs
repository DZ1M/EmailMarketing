using EmailMarketing.Architecture.Core.Domain;

namespace EmailMarketing.Domain.Entities
{
    public class CampanhaContato : Entity
    {
        public Guid IdCampanha { get; set; }
        public Campanha Campanha { get; set; }
        public Guid IdContato { get; set; }
        public Contato Contato { get; set; }
        public string Codigo { get; set; }
        public ICollection<CampanhaContatoAcao> Acoes { get; set; }
    }
}
