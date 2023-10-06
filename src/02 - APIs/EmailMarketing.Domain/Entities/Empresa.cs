using EmailMarketing.Architecture.Core.Domain;

namespace EmailMarketing.Domain.Entities
{
    public class Empresa : Entity
    {
        protected Empresa() { }
        public Empresa(string nome)
        {
            Nome = nome;
            Ativo = true;
        }
        public string? Nome { get; private set; }
        public bool Ativo { get; private set; }
    }
}
