using EmailMarketing.Architecture.Core.Messages;
using MediatR;

namespace EmailMarketing.Application.Admin.Auth.Register
{
    public class RegisterUsuarioCommand : Command, IRequest<Unit>
    {
        /// <summary>Nome do Usuário</summary>
        /// <example>Valdemar</example>
        public string? Nome { get; set; }
        /// <summary>Nome da Empresa</summary>
        /// <example>Frutas do Sidi</example>
        public string? NomeEmpresa { get; set; }
        /// <summary>Email</summary>
        /// <example>teste@teste.com</example>
        public string? Email { get; set; }
        /// <summary>Senha</summary>
        /// <example>123456</example>
        public string? Senha { get; set; }
        /// <summary>Confirmação de Senha</summary>
        /// <example>123456</example>
        public string? SenhaConfirmacao { get; set; }
    }
}
