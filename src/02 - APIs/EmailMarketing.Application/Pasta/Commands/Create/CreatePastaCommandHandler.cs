using EmailMarketing.Application.DTOs;
using EmailMarketing.Architecture.Core.Exceptions;
using EmailMarketing.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Entity = EmailMarketing.Domain.Entities;

namespace EmailMarketing.Application.Pasta.Commands.Create
{
    public class CreatePastaCommandHandler : IRequestHandler<CreatePastaCommand, PastaDto>
    {
        private readonly IUnitOfWork _repository;
        public CreatePastaCommandHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<PastaDto> Handle(CreatePastaCommand request, CancellationToken cancellationToken)
        {
            if (await _repository.Pastas.Query()
                .AnyAsync(where => 
                            where.IdEmpresa == request.IdEmpresa &&
                            EF.Functions.Unaccent(where.Nome.ToLower()) == EF.Functions.Unaccent($"{request.Nome.ToLower()}")))
            {
                ValidationException.ThrowException("Pasta","Já existe uma pasta com este mesmo nome");
            }

            var obj = new Entity.Pasta(request.Nome, request.IdEmpresa, request.IdUsuario);
            _repository.Pastas.Create(obj);

            var complete = await _repository.CommitAsync();

            if (complete is false)
            {
                ValidationException.ThrowException("Pasta", "Houve um erro ao persistir os dados.");
            }

            return PastaDto.New(obj);
        }
    }
}