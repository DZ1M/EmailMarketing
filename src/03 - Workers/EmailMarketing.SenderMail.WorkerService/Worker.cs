using EmailMarketing.Architecture.Core.Exceptions;
using EmailMarketing.Architecture.Core.Messages.Integration;
using EmailMarketing.Architecture.Helpers;
using EmailMarketing.Architecture.MessageBus;
using EmailMarketing.SenderMail.Application.EnviarEmail;
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
            bool stop = true;
            while (stop)
            {
                try
                {
                    await _bus.SubscribeAsync<SendMessageIntegrationEvent>("SendMessage", EnviarMensagem);
                    stop = false;
                }
                catch (Exception ex)
                {
                    stop = true;
                    _logger.LogError(ex, "Conexão com RabbitMQ indisponivel!");
                }
                finally
                {
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
            }
        }
        private async Task EnviarMensagem(SendMessageIntegrationEvent message)
        {
            Console.WriteLine(JsonHelper.Serialize(message));
            var command = new EnviarMensagemCommand(message.Nome, message.Email, message.Texto, message.Codigo, message.IdEmpresa);
            using var scope = _serviceProvider.CreateScope();

            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            var sucesso = await mediator.Send(command);

            if (!sucesso)
            {
                _logger.LogError("Erro ao processar mensagem");
                throw new DomainException($"Falhou ao enviar");
            }
        }
    }
}