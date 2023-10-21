using EmailMarketing.Application.DTOs;
using EmailMarketing.Architecture.Core.Exceptions;
using EmailMarketing.Architecture.Core.Messages.Integration;
using EmailMarketing.Architecture.MessageBus;
using EmailMarketing.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Entity = EmailMarketing.Domain.Entities;

namespace EmailMarketing.Application.Campanha.Commands.Create
{
    public class CreateCampanhaCommandHandler : IRequestHandler<CreateCampanhaCommand, Guid>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMessageBus _bus;
        public CreateCampanhaCommandHandler(IMessageBus bus, IUnitOfWork repository)
        {
            _bus = bus;
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateCampanhaCommand request, CancellationToken cancellationToken)
        {
            if (await _repository.Campanhas.Query()
                .AnyAsync(where => 
                            where.IdEmpresa == request.IdEmpresa &&
                            EF.Functions.Unaccent(where.Nome.ToLower()) == EF.Functions.Unaccent($"{request.Nome.ToLower()}")))
            {
                ValidationException.ThrowException("Campanha","Já existe uma pasta com este mesmo nome");
            }

            var objToCreate = new Entity.Campanha(
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


            var contatosToDatabase = await _repository.Pastas.Query().AsNoTrackingWithIdentityResolution()
                .Include(contatos => contatos.ContatoPastas)
                .Where(where => request.IdPastas.Equals(where.Id) && where.IdEmpresa == request.IdEmpresa)
                .SelectMany(pasta => pasta.ContatoPastas.Select(contatoPasta => contatoPasta.ContatoId))
                .Distinct()
                .ToListAsync();

            foreach (var contato in contatosToDatabase)
            {
                objToCreate.AddContato(contato);
            }

            _repository.Campanhas.Create(objToCreate);

            var complete = await _repository.CommitAsync();

            if (complete is false)
            {
                ValidationException.ThrowException("Pasta", "Houve um erro ao persistir os dados.");
            }

            foreach (var contato in objToCreate.Contatos)
            {
                var nome = request.Nome.Replace("@nome", contato.Contato.Nome);
                
                var command = new MensagemIntegrationEvent
                    (Guid.NewGuid(),
                    nome,
                    contato.Contato.Email,
                    objToCreate.Modelo.Texto,
                    contato.Codigo,
                    request.IdEmpresa);
               
                await _bus.PublishAsync(command);
            }

            return objToCreate.Id;
        }
    }
}