using EmailMarketing.Application.DTOs;
using EmailMarketing.Architecture.Core.Messages;
using EmailMarketing.Domain.Enums;
using MediatR;

namespace EmailMarketing.Application.Modelo.Commands.Create
{
    public class CreateModeloCommand : Command, IRequest<ModeloDto>
    {
        /// <summary>Nome do Modelo</summary>
        /// <example>Template 01</example>
        public string? Nome { get; set; }
        /// <summary>Texto do Modelo</summary>
        /// <example>Código HTML</example>
        public string? Texto { get; set; }
        /// <summary>Tipo de Modelo</summary>
        /// <example>Email</example>
        public TipoMensagemEnum Tipo { get; set; }
    }
}
