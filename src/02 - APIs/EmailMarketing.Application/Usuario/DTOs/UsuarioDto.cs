namespace EmailMarketing.Application.DTOs
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public List<UsuarioPermissaoDto> Roles { get; set; }
        public static UsuarioDto New(EmailMarketing.Domain.Entities.Usuario usuario)
        {
            return new UsuarioDto
            {
                Id = usuario.Id,
                Ativo = usuario.Ativo,
                DataCadastro = usuario.CriadoEm,
                Email = usuario.Email,
                Nome = usuario.Nome,
                Roles = usuario.Permissoes.Select(UsuarioPermissaoDto.New).ToList(),
            };
        }
    }
}
