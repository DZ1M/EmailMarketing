using EmailMarketing.Application.DTOs;
using EmailMarketing.Architecture.Core.Messages;
using MediatR;

namespace EmailMarketing.Application.Pasta.Commands.Create
{
    public class CreatePastaCommand : Command, IRequest<PastaDto>
    {
        /// <summary>Nome da Pasta</summary>
        /// <example>Contatos Importados</example>
        public string? Nome { get; set; }
    }
}
