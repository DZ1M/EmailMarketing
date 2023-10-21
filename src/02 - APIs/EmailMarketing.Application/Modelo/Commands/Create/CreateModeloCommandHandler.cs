using EmailMarketing.Application.DTOs;
using EmailMarketing.Architecture.Core.Exceptions;
using EmailMarketing.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Entity = EmailMarketing.Domain.Entities;

namespace EmailMarketing.Application.Modelo.Commands.Create
{
    public class CreateModeloCommandHandler : IRequestHandler<CreateModeloCommand, ModeloDto>
    {
        private readonly IUnitOfWork _repository;
        public CreateModeloCommandHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<ModeloDto> Handle(CreateModeloCommand request, CancellationToken cancellationToken)
        {
            if (await _repository.Modelos.Query()
                .AnyAsync(where => 
                            where.IdEmpresa == request.IdEmpresa &&
                            EF.Functions.Unaccent(where.Nome.ToLower()) == EF.Functions.Unaccent($"{request.Nome.ToLower()}")))
            {
                ValidationException.ThrowException("Modelo","Já existe um modelo com este mesmo nome");
            }

            var obj = new Entity.Modelo(request.Nome, request.Texto, request.Tipo, request.IdEmpresa, request.IdUsuario);
            _repository.Modelos.Create(obj);

            var complete = await _repository.CommitAsync();

            if (complete is false)
            {
                ValidationException.ThrowException("Modelo", "Houve um erro ao persistir os dados.");
            }

            return ModeloDto.New(obj);
        }
    }
}