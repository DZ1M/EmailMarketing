using EmailMarketing.Application.DTOs;
using EmailMarketing.Architecture.Core.Messages;
using MediatR;
using System.Text.Json.Serialization;

namespace EmailMarketing.Application.Pasta.Commands.Update
{
    public class UpdatePastaCommand : Command, IRequest<PastaDto>
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        /// <summary>Nome da Pasta</summary>
        /// <example>Contatos Importados</example>
        public string? Nome { get; set; }
    }
}
