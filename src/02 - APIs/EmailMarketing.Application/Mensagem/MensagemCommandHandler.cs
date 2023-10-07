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
            for (var i = 0; i < 10; i++)
            {
                var command = new MensagemIntegrationEvent(Guid.NewGuid(), "Teste", "teste@teste.com", "teste 123");
                await _bus.PublishAsync(command);
            }
            return Unit.Value;
        }
    }
}
