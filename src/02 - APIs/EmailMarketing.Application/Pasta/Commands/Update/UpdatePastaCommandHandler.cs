using EmailMarketing.Application.DTOs;
using EmailMarketing.Architecture.Core.Exceptions;
using EmailMarketing.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmailMarketing.Application.Pasta.Commands.Update
{
    public class UpdatePastaCommandHandler : IRequestHandler<UpdatePastaCommand, PastaDto>
    {
        private readonly IUnitOfWork _repository;
        public UpdatePastaCommandHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<PastaDto> Handle(UpdatePastaCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repository
                .Pastas
                .Query()
                .FirstOrDefaultAsync(where => where.Id == request.Id && where.IdEmpresa == request.IdEmpresa, cancellationToken);

            if (obj is null)
            {
               throw ValidationException.GetException("Pasta", "Não encontrada!");
            }

            if (request.Nome is not null && await _repository
                .Pastas
                .Query()
                .AnyAsync(where =>
                                where.Id != request.Id &&
                                where.IdEmpresa == request.IdEmpresa &&
                                EF.Functions.Unaccent(where.Nome.ToLower()) == EF.Functions.Unaccent($"{request.Nome.ToLower()}"),cancellationToken))
            {

                ValidationException.ThrowException("Pasta", "Já existe uma pasta com este mesmo nome");

            }

            obj.Update(request.Nome, request.IdUsuario);

            _repository.Pastas.Update(obj);

            var complete = await _repository.CommitAsync();

            if (!complete)
            {
               throw ValidationException.GetException("Pasta", "Houve um erro ao persistir os dados.");
            }

            return PastaDto.New(obj);
        }
    }
}
