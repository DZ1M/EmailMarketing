using EmailMarketing.Architecture.Core.Domain;

namespace EmailMarketing.Domain.Entities
{
    public class Usuario : Entity
    {
        protected Usuario() { }
        public string? Nome { get; private set; }
        public string? Email { get; private set; }
        public string? Senha { get; private set; }
        public string? Descricao { get; private set; }
        public string? Telefone { get; private set; }
        public string? Url { get; private set; }
        public bool Ativo { get; private set; }
        public List<UsuarioPermissao> Permissoes { get; private set; } = new List<UsuarioPermissao>();
        public List<UsuarioEmpresa> Empresas { get; private set; } = new List<UsuarioEmpresa>();

        public Usuario(string? nome, string? email, string? senha, string? descricao, string? telefone, string? url)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Descricao = descricao;
            Telefone = telefone;
            Url = url;
            Ativo = true;
        }
        public void AlterarDados(string? nome)
        {
            if (nome is not null && Nome.Equals(nome) is not true) Nome = nome;
        }
        public void AlterarSenha(string senha)
        {
            Senha = senha;
        }
        public void AddRole(UsuarioPermissao role)
        {
            Permissoes ??= new List<UsuarioPermissao>();

            Permissoes.Add(role);
        }
        public void AddEmpresa(UsuarioEmpresa empresa)
        {
            Empresas ??= new List<UsuarioEmpresa>();

            Empresas.Add(empresa);
        }
    }
}
