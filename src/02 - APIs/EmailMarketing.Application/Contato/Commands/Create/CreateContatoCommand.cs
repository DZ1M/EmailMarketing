using EmailMarketing.Application.DTOs;
using EmailMarketing.Architecture.Core.Messages;
using MediatR;

namespace EmailMarketing.Application.Contato.Commands.Create
{
    public class CreateContatoCommand : Command, IRequest<ContatoDto>
    {
        /// <summary>Nome do Contato</summary>
        /// <example>João Teimoso</example>
        public string? Nome { get; set; }
        /// <summary>Email do Contato</summary>
        /// <example>teste@exemplo.com</example>
        public string? Email { get; set; }
        /// <summary>Telefone do Contato</summary>
        /// <example>5535353535</example>
        public string? Telefone { get; set; }
        /// <summary>Id da Pasta</summary>
        /// <example>591d67c5-c25b-4aab-93a3-118b48c1e3c2</example>
        public Guid IdPasta { get; set; }
    }
}
