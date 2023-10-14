using EmailMarketing.Architecture.Core.Domain;

namespace EmailMarketing.Domain.Entities
{
    public class Pasta : Entity
    {
        public string? Nome { get; set; }
        public ICollection<ContatoPasta> ContatoPastas { get; set; }
    }
}
