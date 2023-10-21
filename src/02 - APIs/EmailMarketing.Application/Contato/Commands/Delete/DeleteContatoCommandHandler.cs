using EmailMarketing.Architecture.Core.Exceptions;
using EmailMarketing.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmailMarketing.Application.Contato.Commands.Delete
{
    public class DeleteContatoCommandHandler : IRequestHandler<DeleteContatoCommand, Unit>
    {
        private readonly IUnitOfWork _repository;
        public DeleteContatoCommandHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteContatoCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repository.Contatos.Query().FirstOrDefaultAsync(where => where.Id == request.Id && where.IdEmpresa == request.IdEmpresa);

            if (obj is null)
            {
                ValidationException.ThrowException("Contato", "Não encontrado!");
            }

            _repository.Contatos.Delete(obj);

            var complete = await _repository.CommitAsync();

            if (complete is false)
            {
                ValidationException.ThrowException("Contato", "Houve um erro ao persistir os dados.");
            }

            return Unit.Value;
        }
    }
}
