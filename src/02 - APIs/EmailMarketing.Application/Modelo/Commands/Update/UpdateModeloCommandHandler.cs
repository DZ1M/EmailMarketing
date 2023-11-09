using EmailMarketing.Application.DTOs;
using EmailMarketing.Architecture.Core.Exceptions;
using EmailMarketing.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmailMarketing.Application.Modelo.Commands.Update
{
    public class UpdateModeloCommandHandler : IRequestHandler<UpdateModeloCommand, ModeloDto>
    {
        private readonly IUnitOfWork _repository;
        public UpdateModeloCommandHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<ModeloDto> Handle(UpdateModeloCommand request, CancellationToken cancellationToken)
        {
            var modeloToUpdate = await _repository.Modelos.Query().FirstOrDefaultAsync(where => where.Id == request.Id && where.IdEmpresa == request.IdEmpresa, cancellationToken);
            
            if(modeloToUpdate is null)
            {
              throw ValidationException.GetException("Modelo", "Não encontrada!");
            }

            if (request.Nome is not null)
            {
                if (await _repository.Modelos.Query()
                    .AnyAsync(where =>
                                where.Id != request.Id &&
                                where.IdEmpresa == request.IdEmpresa &&
                                EF.Functions.Unaccent(where.Nome.ToLower()) == EF.Functions.Unaccent($"{request.Nome.ToLower()}"),cancellationToken))
                {
                    ValidationException.ThrowException("Modelo", "Já existe uma pasta com este mesmo nome");
                }
            }

            modeloToUpdate.Update(request.Nome, request.Texto, request.Tipo, request.IdUsuario);

            _repository.Modelos.Update(modeloToUpdate);

            var complete = await _repository.CommitAsync();

            if (complete is false)
            {
                ValidationException.ThrowException("Modelo", "Houve um erro ao persistir os dados.");
            }

            return ModeloDto.New(modeloToUpdate);
        }
    }
}
