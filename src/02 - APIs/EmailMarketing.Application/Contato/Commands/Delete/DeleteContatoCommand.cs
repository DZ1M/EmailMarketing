using EmailMarketing.Architecture.Core.Messages;
using MediatR;
using System.Text.Json.Serialization;

namespace EmailMarketing.Application.Contato.Commands.Delete
{
    public class DeleteContatoCommand : Command, IRequest<Unit>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
