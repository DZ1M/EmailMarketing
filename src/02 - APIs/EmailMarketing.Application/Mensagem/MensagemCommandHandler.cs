using EmailMarketing.Architecture.Core.Messages.Integration;
using EmailMarketing.Architecture.Helpers;
using EmailMarketing.Architecture.MessageBus;
using MediatR;

namespace EmailMarketing.Application.Mensagem
{
    public class MensagemCommandHandler : IRequestHandler<MensagemCommand, Unit>
    {
        private readonly IMessageBus _bus;
        public MensagemCommandHandler(IMessageBus bus)
        {
            _bus = bus;
        }

        public async Task<Unit> Handle(MensagemCommand request, CancellationToken cancellationToken)
        {
            // Send QUEUE

            var codigoUrl = Guid.NewGuid().ToString()[..8] + ".png";

            // Aqui vai salvar a mensagem no banco 

            // Aqui dispara a mensagem para a fila
            var command = new MensagemIntegrationEvent(Guid.NewGuid(), "Teste", "teste@teste.com", "teste 123", codigoUrl, request.IdEmpresa);
            await _bus.PublishAsync(command);

            return Unit.Value;
        }
    }
}
