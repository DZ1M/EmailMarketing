using EmailMarketing.Application.DTOs;
using MediatR;

namespace EmailMarketing.Application.Usuario.Queries.GerarJwt
{
    public class GerarTokenCommand : IRequest<UsuarioRespostaLogin>
    {
        /// <summary>Email</summary>
        /// <example>teste@teste.com</example>
        public string? Email { get; set; }
        /// <summary>Id da Empresa</summary>
        /// <example>eca362b2-c9c1-4dc5-9787-7d5263cb79b4</example>
        public Guid IdEmpresa { get; set; }
    }
}
