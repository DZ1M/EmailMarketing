using EmailMarketing.Application.DTOs;
using EmailMarketing.Architecture.Core.Domain;
using EmailMarketing.Architecture.Core.Messages;
using EmailMarketing.Architecture.Helpers;
using EmailMarketing.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Entity = EmailMarketing.Domain.Entities;

namespace EmailMarketing.Application.Contato.Queries.ListAll
{
    public class GetAllContatoQuery : Command, IRequest<ListaPaginada<ContatoDto>>
    {
        [JsonIgnore]
        public int Length { get; set; }
        [JsonIgnore]
        public int Start { get; set; }
        [JsonIgnore]
        public string? Search { get; set; }
        [JsonIgnore]
        public string? SortColumn { get; set; }
        [JsonIgnore]
        public string? SortColumnDirection { get; set; }
    }
    public class GetAllContatoQueryHandler : IRequestHandler<GetAllContatoQuery, ListaPaginada<ContatoDto>>
    {
        private readonly IUnitOfWork _repository;

        public GetAllContatoQueryHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<ListaPaginada<ContatoDto>> Handle(GetAllContatoQuery request, CancellationToken cancellationToken)
        {

            request.Search ??= string.Empty;

            var result = new ListaPaginada<Entity.Contato>
            {
                Query = request.Search,
                RegistrosPorPagina = request.Length,
                Pagina = request.Start,
                TotalRegistros = await _repository.Contatos.Query().AsNoTrackingWithIdentityResolution()
                                            .Where(x => EF.Functions.ILike(EF.Functions.Unaccent(x.Nome), $"%{request.Search.Replace(" ", "%")}%"))
                                            .CountAsync(),
                Lista = _repository.Contatos.Query().AsNoTrackingWithIdentityResolution()
                                            .Where(x => EF.Functions.ILike(EF.Functions.Unaccent(x.Nome), $"%{request.Search.Replace(" ", "%")}%"))
                                            .FiltrarPaginado(request.Start, request.Length, request.SortColumn, request.SortColumnDirection).ToList()
            };

            result.CalcularRegistros();

            return new ListaPaginada<ContatoDto>
            {
                NumeroPaginas = result.NumeroPaginas,
                Pagina = result.Pagina,
                Query = result.Query,
                ReferenceAction = result.ReferenceAction,
                RegistroFinal = result.RegistroFinal,
                RegistroInicial = result.RegistroInicial,
                RegistrosPorPagina = result.RegistrosPorPagina,
                TotalRegistros = result.TotalRegistros,
                Lista = result.Lista.Select(x => ContatoDto.New(x)).ToList()
            };
        }
    }
}
