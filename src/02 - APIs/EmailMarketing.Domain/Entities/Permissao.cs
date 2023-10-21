using EmailMarketing.Architecture.Core.Domain;

namespace EmailMarketing.Domain.Entities
{
    public class Permissao : Entity
    {
        protected Permissao() { }
        public Permissao(string? nome, string? valor)
        {
            Nome = nome;
            Valor = valor;
            Default = false;
        }
        public Permissao(string? nome, string? valor, bool @default = false)
        {
            Nome = nome;
            Valor = valor;
            Default = @default;
        }
        public string? Nome { get; private set; }
        public string? Valor { get; private set; }
        public bool Default { get; private set; }
    }
}
