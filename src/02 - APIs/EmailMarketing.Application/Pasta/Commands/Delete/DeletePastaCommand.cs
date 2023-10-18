using EmailMarketing.Application.DTOs;
using EmailMarketing.Architecture.Core.Messages;
using MediatR;
using System.Text.Json.Serialization;

namespace EmailMarketing.Application.Pasta.Commands.Delete
{
    public class DeletePastaCommand : Command, IRequest<Unit>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
