using EmailMarketing.Architecture.Core.Domain;

namespace EmailMarketing.Domain.Entities
{
    public class Modelo : Entity
    {
        public string Nome { get; private set; }
        public string Texto { get; private set; }
    }
}
