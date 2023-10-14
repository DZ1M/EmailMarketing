using EmailMarketing.Architecture.Core.Domain;

namespace EmailMarketing.Domain.Entities
{
    public class Contato : Entity
    {
        public string? Nome { get; set; }
        public Email? Email { get; set; }
    }
}
