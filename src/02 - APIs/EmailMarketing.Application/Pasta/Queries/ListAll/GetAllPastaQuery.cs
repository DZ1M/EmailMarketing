using EmailMarketing.Application.DTOs;
using EmailMarketing.Architecture.Core.Domain;
using EmailMarketing.Architecture.Core.Messages;
using EmailMarketing.Architecture.Helpers;
using EmailMarketing.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Entity = EmailMarketing.Domain.Entities;

namespace EmailMarketing.Application.Pasta.Queries.ListAll
{
    public class GetAllPastaQuery : Command, IRequest<ListaPaginada<PastaDto>>
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
    public class GetAllPastaQueryHandler : IRequestHandler<GetAllPastaQuery, ListaPaginada<PastaDto>>
    {
        private readonly IUnitOfWork _repository;

        public GetAllPastaQueryHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<ListaPaginada<PastaDto>> Handle(GetAllPastaQuery request, CancellationToken cancellationToken)
        {

            request.Search ??= string.Empty;

            var result = new ListaPaginada<Entity.Pasta>
            {
                Query = request.Search,
                RegistrosPorPagina = request.Length,
                Pagina = request.Start,
                TotalRegistros = await _repository.Pastas.Query().AsNoTrackingWithIdentityResolution()
                                            .Where(x => EF.Functions.ILike(EF.Functions.Unaccent(x.Nome), $"%{request.Search.Replace(" ", "%")}%"))
                                            .CountAsync(),
                Lista = _repository.Pastas.Query().AsNoTrackingWithIdentityResolution()
                                            .Where(x => EF.Functions.ILike(EF.Functions.Unaccent(x.Nome), $"%{request.Search.Replace(" ", "%")}%"))
                                            .FiltrarPaginado(request.Start, request.Length, request.SortColumn, request.SortColumnDirection).ToList()
            };

            result.CalcularRegistros();

            return new ListaPaginada<PastaDto>
            {
                NumeroPaginas = result.NumeroPaginas,
                Pagina = result.Pagina,
                Query = result.Query,
                ReferenceAction = result.ReferenceAction,
                RegistroFinal = result.RegistroFinal,
                RegistroInicial = result.RegistroInicial,
                RegistrosPorPagina = result.RegistrosPorPagina,
                TotalRegistros = result.TotalRegistros,
                Lista = result.Lista.Select(x => PastaDto.New(x)).ToList()
            };
        }
    }
}
