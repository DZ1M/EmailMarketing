using EmailMarketing.Application.DTOs;
using EmailMarketing.Architecture.Core.Messages;
using MediatR;
using System.Text.Json.Serialization;

namespace EmailMarketing.Application.Modelo.Commands.Delete
{
    public class DeleteModeloCommand : Command, IRequest<Unit>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
