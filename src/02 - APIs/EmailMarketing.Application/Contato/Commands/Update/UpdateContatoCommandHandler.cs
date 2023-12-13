using EmailMarketing.Application.DTOs;
using EmailMarketing.Architecture.Core.Exceptions;
using EmailMarketing.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmailMarketing.Application.Contato.Commands.Update
{
    public class UpdateContatoCommandHandler : IRequestHandler<UpdateContatoCommand, ContatoDto>
    {
        private readonly IUnitOfWork _repository;
        public UpdateContatoCommandHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<ContatoDto> Handle(UpdateContatoCommand request, CancellationToken cancellationToken)
        {
            var contatoToUpdate = await _repository.Contatos.Query().FirstOrDefaultAsync(where => where.Id == request.Id && where.IdEmpresa == request.IdEmpresa);

            if (contatoToUpdate is null)
            {
                throw ValidationException.GetException("Contato", "Não encontrado!");
            }

            contatoToUpdate.Update(request.Nome, request.Email, request.Telefone, request.IdUsuario);

            _repository.Contatos.Update(contatoToUpdate);

            var complete = await _repository.CommitAsync();

            if (complete is false)
            {
                throw ValidationException.GetException("Contato", "Houve um erro ao persistir os dados.");
            }

            return ContatoDto.New(contatoToUpdate);
        }
    }
}
