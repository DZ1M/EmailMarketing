using EmailMarketing.Application.DTOs;
using EmailMarketing.Architecture.Core.Domain;
using EmailMarketing.Architecture.Core.Messages;
using EmailMarketing.Architecture.Helpers;
using EmailMarketing.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Entity = EmailMarketing.Domain.Entities;

namespace EmailMarketing.Application.Modelo.Queries.ListAll
{
    public class GetAllModeloQuery : Command, IRequest<ListaPaginada<ModeloDto>>
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
    public class GetAllModeloQueryHandler : IRequestHandler<GetAllModeloQuery, ListaPaginada<ModeloDto>>
    {
        private readonly IUnitOfWork _repository;

        public GetAllModeloQueryHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<ListaPaginada<ModeloDto>> Handle(GetAllModeloQuery request, CancellationToken cancellationToken)
        {

            request.Search ??= string.Empty;

            var result = new ListaPaginada<Entity.Modelo>
            {
                Query = request.Search,
                RegistrosPorPagina = request.Length,
                Pagina = request.Start,
                TotalRegistros = await _repository.Modelos.Query().AsNoTrackingWithIdentityResolution()
                                            .Where(x => EF.Functions.ILike(EF.Functions.Unaccent(x.Nome), $"%{request.Search.Replace(" ", "%")}%"))
                                            .CountAsync(),
                Lista = _repository.Modelos.Query().AsNoTrackingWithIdentityResolution()
                                            .Where(x => EF.Functions.ILike(EF.Functions.Unaccent(x.Nome), $"%{request.Search.Replace(" ", "%")}%"))
                                            .FiltrarPaginado(request.Start, request.Length, request.SortColumn, request.SortColumnDirection).ToList()
            };

            result.CalcularRegistros();

            return new ListaPaginada<ModeloDto>
            {
                NumeroPaginas = result.NumeroPaginas,
                Pagina = result.Pagina,
                Query = result.Query,
                ReferenceAction = result.ReferenceAction,
                RegistroFinal = result.RegistroFinal,
                RegistroInicial = result.RegistroInicial,
                RegistrosPorPagina = result.RegistrosPorPagina,
                TotalRegistros = result.TotalRegistros,
                Lista = result.Lista.Select(x => ModeloDto.New(x)).ToList()
            };
        }
    }
}
