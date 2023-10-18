using EmailMarketing.Architecture.Core.Exceptions;
using EmailMarketing.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmailMarketing.Application.Pasta.Commands.Delete
{
    public class DeletePastaCommandHandler : IRequestHandler<DeletePastaCommand, Unit>
    {
        private readonly IUnitOfWork _repository;
        public DeletePastaCommandHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeletePastaCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repository.Pastas.Query().FirstOrDefaultAsync(where => where.Id == request.Id && where.IdEmpresa == request.IdEmpresa);

            if (obj is null)
            {
                ValidationException.ThrowException("Pasta", "Não encontrada!");
            }

            _repository.Pastas.Delete(obj);

            var complete = await _repository.CommitAsync();

            if (complete is false)
            {
                ValidationException.ThrowException("Pasta", "Houve um erro ao persistir os dados.");
            }

            return Unit.Value;
        }
    }
}
