using EmailMarketing.Architecture.WebApi.Core.Logs.Contracts;
using EmailMarketing.Domain.Entities;
using EmailMarketing.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmailMarketing.Application.CampanhaContato.Commands.AddNewStatus
{
    public class AddNewStatusCommandHandler : IRequestHandler<AddNewStatusCommand, Unit>
    {
        private readonly IUnitOfWork _repository;
        private readonly IAppLogger _logger;

        public AddNewStatusCommandHandler(IUnitOfWork repository, IAppLogger logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<Unit> Handle(AddNewStatusCommand request, CancellationToken cancellationToken)
        {
            var objToInsert = await _repository.CampanhaContatos
                .Query()
                .AsNoTrackingWithIdentityResolution()
                .Include(acao => acao.Acoes)
                .FirstOrDefaultAsync(where => where.Codigo == request.Code);

            if (objToInsert is null)
            {
                _logger.LogInfo($"O Code: {request.Code} não foi encontrado!");
                return Unit.Value;
            }

            if (objToInsert.Acoes.Any(where => where.Acao == request.Acao))
            {
                _logger.LogInfo($"E-mail já tem a ação: {request.Acao}");
                return Unit.Value;
            }

            var acao = new CampanhaContatoAcao(objToInsert.Id, request.Acao);
            _repository.CampanhaContatosAcoes.Create(acao);

            await _repository.CommitAsync();

            return Unit.Value;
        }
    }
}
