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
            var obj = await _repository.Contatos.Query().FirstOrDefaultAsync(where => where.Id == request.Id && where.IdEmpresa == request.IdEmpresa);
            
            if(obj is null)
            {
                ValidationException.ThrowException("Contato", "Não encontrado!");
            }

            obj.Update(request.Nome, request.Email, request.Telefone, request.IdUsuario);

            _repository.Contatos.Update(obj);

            var complete = await _repository.CommitAsync();

            if (complete is false)
            {
                ValidationException.ThrowException("Contato", "Houve um erro ao persistir os dados.");
            }

            return ContatoDto.New(obj);
        }
    }
}
