using EmailMarketing.Architecture.Core.Exceptions;
using EmailMarketing.Architecture.Core.Messages.Integration;
using EmailMarketing.Architecture.MessageBus;
using EmailMarketing.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmailMarketing.API.Services
{
    public class BuildMessageIntegrationHandler : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<BuildMessageIntegrationHandler> _logger;

        public BuildMessageIntegrationHandler(IMessageBus bus, IServiceProvider serviceProvider, ILogger<BuildMessageIntegrationHandler> logger)
        {
            _bus = bus;
            _serviceProvider = serviceProvider;
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _bus.SubscribeAsync<BuildMessageIntegrationEvent>("BuildMessage", ProcessMessages);
        }
        private async Task ProcessMessages(BuildMessageIntegrationEvent message)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var repository = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();


                var campanhasToSend = await repository.Campanhas.Query()
                    .Include(x => x.Contatos)
                        .ThenInclude(c => c.Contato)
                    .Include(x => x.Modelo)
                    .AsNoTrackingWithIdentityResolution()
                    .FirstOrDefaultAsync(where => where.Id == message.Id && where.IdEmpresa == message.IdEmpresa);

                if (campanhasToSend is null)
                {
                    throw new DomainException($"Não foi possivel localizar a campanha id: {message.Id} da empresa id: {message.IdEmpresa}");
                }

                foreach (var contato in campanhasToSend.Contatos.DistinctBy(c => c.Contato.Email))
                {
                    try
                    {
                        var nome = campanhasToSend.Titulo.Replace("@nome", contato.Contato.Nome);

                        var command = new SendMessageIntegrationEvent
                            (Guid.NewGuid(),
                            nome,
                            contato.Contato.Email,
                            campanhasToSend.Modelo.Texto,
                            contato.Codigo,
                            campanhasToSend.IdEmpresa);

                        await _bus.PublishAsync(command);

                        _logger.LogInformation($"Mensagem enviada para o contato {contato.Contato.Email} a campanha id: {message.Id}.");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.Message, $"Ocorreu um erro ao enviar a campanha id: {message.Id}.");
                    }
                }
            }
        }
    }
}
