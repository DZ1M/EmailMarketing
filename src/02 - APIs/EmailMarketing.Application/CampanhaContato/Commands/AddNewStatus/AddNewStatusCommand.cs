using EmailMarketing.Architecture.Core.Messages;
using MediatR;
using System.Text.Json.Serialization;

namespace EmailMarketing.Application.CampanhaContato.Commands.AddNewStatus
{
    public class AddNewStatusCommand : Command, IRequest<Unit>
    {
        [JsonIgnore]
        public string Code { get; set; }
        [JsonIgnore]
        public Domain.Enums.AcaoMensagemEnum Acao { get; set; }
    }
}
