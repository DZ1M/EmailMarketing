using EmailMarketing.Architecture.Core.Exceptions;
using EmailMarketing.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmailMarketing.Application.Modelo.Commands.Delete
{
    public class DeleteModeloCommandHandler : IRequestHandler<DeleteModeloCommand, Unit>
    {
        private readonly IUnitOfWork _repository;
        public DeleteModeloCommandHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteModeloCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repository.Modelos.Query().FirstOrDefaultAsync(where => where.Id == request.Id && where.IdEmpresa == request.IdEmpresa);

            if (obj is null)
            {
                ValidationException.ThrowException("Modelo", "Não encontrada!");
            }

            _repository.Modelos.Delete(obj);

            var complete = await _repository.CommitAsync();

            if (complete is false)
            {
                ValidationException.ThrowException("Modelo", "Houve um erro ao persistir os dados.");
            }

            return Unit.Value;
        }
    }
}
