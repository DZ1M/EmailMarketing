using EmailMarketing.Architecture.Core.Domain;
using EmailMarketing.Domain.Enums;

namespace EmailMarketing.Domain.Entities
{
    public class Campanha : Entity
    {
        protected Campanha() { }
        public Campanha(TipoMensagemEnum tipoMensagem, string nome, string titulo, DateTime data, Guid idModelo, Guid idEmpresa, Guid idUsuario)
        {
            TipoMensagem = tipoMensagem;
            Nome = nome;
            Titulo = titulo;
            Data = data;
            IdModelo = idModelo;
            IdEmpresa = idEmpresa;
            CriadoEm = DateTime.Now;
            CriadoPor = idUsuario;

        }
        public void AddPasta(Guid idPasta)
        {
            if (Pastas is null)
                Pastas = new List<CampanhaPasta>();

            Pastas.Add(new CampanhaPasta(idPasta));
        }
        public void AddContato(Guid idContato)
        {
            if(Contatos is null)
                Contatos = new List<CampanhaContato>();

            Contatos.Add(new CampanhaContato(idContato));
        }
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
