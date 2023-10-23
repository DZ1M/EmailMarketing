using EmailMarketing.Application.DTOs;
using EmailMarketing.Architecture.Core.Exceptions;
using EmailMarketing.Architecture.Core.Messages;
using EmailMarketing.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace EmailMarketing.Application.Modelo.Queries.ById
{
    public class GetModeloByIdQuery : Command, IRequest<ModeloDto>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
    public class GetModeloByIdQueryHandler : IRequestHandler<GetModeloByIdQuery, ModeloDto>
    {
        private readonly IUnitOfWork _repository;
        public GetModeloByIdQueryHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }
        public async Task<ModeloDto> Handle(GetModeloByIdQuery request, CancellationToken cancellationToken)
        {
            var obj = await _repository.Modelos.Query().AsNoTrackingWithIdentityResolution()
                        .FirstOrDefaultAsync(where => where.Id == request.Id && where.IdEmpresa == request.IdEmpresa);

            if (obj is null)
            {
                ValidationException.ThrowException("Modelo", "Não encontrado!");
            }
            
            return ModeloDto.New(obj);
        }
    }
}
