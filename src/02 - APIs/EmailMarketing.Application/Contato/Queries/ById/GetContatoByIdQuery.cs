using EmailMarketing.Application.DTOs;
using EmailMarketing.Architecture.Core.Exceptions;
using EmailMarketing.Architecture.Core.Messages;
using EmailMarketing.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace EmailMarketing.Application.Contato.Queries.ById
{
    public class GetContatoByIdQuery : Command, IRequest<ContatoDto>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
    public class GetContatoByIdQueryHandler : IRequestHandler<GetContatoByIdQuery, ContatoDto>
    {
        private readonly IUnitOfWork _repository;
        public GetContatoByIdQueryHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }
        public async Task<ContatoDto> Handle(GetContatoByIdQuery request, CancellationToken cancellationToken)
        {
            var obj = await _repository.Contatos.Query().AsNoTrackingWithIdentityResolution()
                        .FirstOrDefaultAsync(where => where.Id == request.Id && where.IdEmpresa == request.IdEmpresa);

            if (obj is null)
            {
                ValidationException.ThrowException("Contato", "Não encontrado!");
            }
            
            return ContatoDto.New(obj);
        }
    }
}
