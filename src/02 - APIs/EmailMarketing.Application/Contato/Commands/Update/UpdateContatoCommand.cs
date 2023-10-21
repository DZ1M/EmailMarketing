using EmailMarketing.Application.DTOs;
using EmailMarketing.Architecture.Core.Messages;
using MediatR;
using System.Text.Json.Serialization;

namespace EmailMarketing.Application.Contato.Commands.Update
{
    public class UpdateContatoCommand : Command, IRequest<ContatoDto>
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        /// <summary>Nome do Contato</summary>
        /// <example>João Teimoso</example>
        public string? Nome { get; set; }
        /// <summary>Email do Contato</summary>
        /// <example>teste@exemplo.com</example>
        public string? Email { get; set; }
        /// <summary>Telefone do Contato</summary>
        /// <example>5535353535</example>
        public string? Telefone { get; set; }
    }
}
