using EmailMarketing.Domain.Entities;

namespace EmailMarketing.Application.DTOs
{
    public class PermissaoDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Valor { get; set; }
        public static PermissaoDto New(Permissao permissao)
        {
            return new PermissaoDto
            {
                Id = permissao.Id,
                Nome = permissao.Nome,
                Valor = permissao.Valor,
            };
        }
    }
}
