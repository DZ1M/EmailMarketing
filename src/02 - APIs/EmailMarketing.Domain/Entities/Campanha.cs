using EmailMarketing.Architecture.Core.Domain;

namespace EmailMarketing.Domain.Entities
{
    public class Campanha : Entity
    {
        public Campanha(string nome, DateTime data, Guid idUsuario)
        {
            Nome = nome;
            Data = data;
            IdUsuario = idUsuario;
        }

        public string Nome { get; private set; }
        public DateTime Data { get; private set; }
        public Guid IdUsuario { get; private set; }
        public Usuario Usuario { get; private set; }
    }
}
