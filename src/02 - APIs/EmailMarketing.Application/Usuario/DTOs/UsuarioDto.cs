namespace EmailMarketing.Application.DTOs
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public List<PermissaoDto> Permissoes { get; set; }
        public List<EmpresaDto> Empresas { get; set; }
        public static UsuarioDto New(EmailMarketing.Domain.Entities.Usuario usuario)
        {
            return new UsuarioDto
            {
                Id = usuario.Id,
                Ativo = usuario.Ativo,
                DataCadastro = usuario.CriadoEm,
                Email = usuario.Email,
                Nome = usuario.Nome,
                Permissoes = usuario.Permissoes.Select(x => PermissaoDto.New(x.Permissao)).ToList(),
                Empresas = usuario.Empresas.Select(usuarioEmpresa => EmpresaDto.New(usuarioEmpresa.Empresa)).ToList()
            };
        }
    }
}
