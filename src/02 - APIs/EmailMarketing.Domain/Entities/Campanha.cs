using EmailMarketing.Architecture.Core.Domain;

namespace EmailMarketing.Domain.Entities
{
    public class Campanha : Entity
    {
        public Campanha(string nome, DateTime data)
        {
            Nome = nome;
            Data = data;
        }

        public string Nome { get; private set; }
        public DateTime Data { get; private set; }
    }
}
