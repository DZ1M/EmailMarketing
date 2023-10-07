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
            var command = new MensagemIntegrationEvent(Guid.NewGuid(), "Teste", "teste@teste.com", "teste 123");
            await _bus.PublishAsync(command);

            // Recevied Queue
            await _bus.SubscribeAsync<MensagemIntegrationEvent>("Mensagem", EnviarMensagem);


            return Unit.Value;
        }
        private async Task EnviarMensagem(MensagemIntegrationEvent message)
        {
            Console.WriteLine(JsonHelper.Serialize(message));
            await Task.CompletedTask;
        }
    }
}
