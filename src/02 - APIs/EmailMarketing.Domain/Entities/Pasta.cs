using EmailMarketing.Architecture.Core.Domain;

namespace EmailMarketing.Domain.Entities
{
    public class Pasta : Entity
    {
        public string Nome { get; private set; } = string.Empty;
        public ICollection<ContatoPasta?>? ContatoPastas { get; private set; }
        protected Pasta() { }
        public Pasta(string nome, Guid idEmpresa, Guid idUsuario)
        {
            Nome = nome;

            CriadoEm = DateTime.Now;
            CriadoPor = idUsuario;
            IdEmpresa = idEmpresa;
        }
        public void Update(string? nome, Guid idUsuario)
        {
            if(nome is not null && Nome.Equals(nome) is not true) Nome = nome;

            AtualizadoEm = DateTime.Now;
            AtualizadoPor = idUsuario;
        }
    }
}
