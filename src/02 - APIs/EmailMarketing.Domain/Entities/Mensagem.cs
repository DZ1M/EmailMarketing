using EmailMarketing.Architecture.Core.Domain;

namespace EmailMarketing.Domain.Entities
{
    public class Mensagem : Entity
    {
        public Mensagem() { }
        public string Nome { get; private set; }
        public string Texto { get; private set; }
        public string CodigoUrl { get; private set; }
        public string EmailDestinatario { get; private set; }
        public bool Entregue { get; private set; }
        public bool Visualizado { get; private set; }
        public bool Clicado { get; private set; }
        public bool Excluido { get; private set; }
        public Guid IdModelo { get; private set; }
        public Guid IdCampanha { get; private set; }

    }
}
