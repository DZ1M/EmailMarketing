using EmailMarketing.Architecture.Core.Messages.Integration;
using EmailMarketing.Architecture.Helpers;
using EmailMarketing.Architecture.MessageBus;
using MediatR;

namespace EmailMarketing.SenderMail.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger, IMessageBus bus, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _bus = bus;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _bus.SubscribeAsync<MensagemIntegrationEvent>("Mensagem", EnviarMensagem);

        }
        private async Task EnviarMensagem(MensagemIntegrationEvent message)
        {
            Console.WriteLine(JsonHelper.Serialize(message));
            using (var scope = _serviceProvider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                //var sucesso = await mediator.Send(clientCommand);
            }
        }
    }
}