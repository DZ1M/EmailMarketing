using EmailMarketing.Architecture.Core.Messages.Integration;
using EmailMarketing.Architecture.Helpers;
using EmailMarketing.Architecture.MessageBus;
using EmailMarketing.Domain.Entities;
using EmailMarketing.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmailMarketing.Application.Mensagem
{
    public class MensagemCommandHandler : IRequestHandler<MensagemCommand, Unit>
    {
        private readonly IMessageBus _bus;
        private readonly IUnitOfWork _unitOfWork;
        public MensagemCommandHandler(IMessageBus bus, IUnitOfWork unitOfWork)
        {
            _bus = bus;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(MensagemCommand request, CancellationToken cancellationToken)
        {
            var objToCreate = new Campanha(
                tipoMensagem: request.Tipo,
                nome: request.Nome,
                titulo: request.Titulo,
                data: DateTime.Today,
                idModelo: request.IdModelo,
                idEmpresa: request.IdEmpresa,
                idUsuario: request.IdUsuario);

            foreach (var idPasta in request.IdPastas)
            {
                objToCreate.AddPasta(idPasta);
            }

            var contatosToDatabase = await _unitOfWork.Pastas.Query().AsNoTrackingWithIdentityResolution()
                .Include(contatos => contatos.ContatoPastas)
                .Where(where => request.IdPastas.Equals(where.Id) && where.IdEmpresa == request.IdEmpresa)
                .SelectMany(pasta => pasta.ContatoPastas.Select(contatoPasta => contatoPasta.ContatoId))
                .Distinct()
                .ToListAsync();

            foreach (var contato in contatosToDatabase)
            {
                objToCreate.AddContato(contato);
            }

            _unitOfWork.Campanhas.Create(objToCreate);

            var result = await _unitOfWork.CommitAsync();

            // Aqui dispara a mensagem para a fila de envio
            //var command = new MensagemIntegrationEvent(Guid.NewGuid(), "Teste", "teste@teste.com", "teste 123", codigoUrl, request.IdEmpresa);
            //await _bus.PublishAsync(command);

            return Unit.Value;
        }
    }
}
