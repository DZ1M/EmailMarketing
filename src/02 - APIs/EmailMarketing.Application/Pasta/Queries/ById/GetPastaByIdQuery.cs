using EmailMarketing.Application.DTOs;
using EmailMarketing.Architecture.Core.Exceptions;
using EmailMarketing.Architecture.Core.Messages;
using EmailMarketing.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace EmailMarketing.Application.Pasta.Queries.ById
{
    public class GetPastaByIdQuery : Command, IRequest<PastaDto>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
    public class GetPastaByIdQueryHandler : IRequestHandler<GetPastaByIdQuery, PastaDto>
    {
        private readonly IUnitOfWork _repository;
        public GetPastaByIdQueryHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }
        public async Task<PastaDto> Handle(GetPastaByIdQuery request, CancellationToken cancellationToken)
        {
            var obj = await _repository.Pastas.Query().AsNoTrackingWithIdentityResolution()
                        .FirstOrDefaultAsync(where => where.Id == request.Id && where.IdEmpresa == request.IdEmpresa);

            if (obj is null)
            {
                ValidationException.ThrowException("Pasta", "Não encontrada!");
            }
            
            return PastaDto.New(obj);
        }
    }
}
