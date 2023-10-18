using EmailMarketing.Application.DTOs;
using EmailMarketing.Architecture.Core.Domain;
using EmailMarketing.Architecture.Core.Messages;
using EmailMarketing.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
            var response = await _repository.Pastas.ListPaginada(request.Length, request.Start, request.Search, request.SortColumn, request.SortColumnDirection);
            return new ListaPaginada<PastaDto>
            {
                NumeroPaginas = response.NumeroPaginas,
                Pagina = response.Pagina,
                Query = response.Query,
                ReferenceAction = response.ReferenceAction,
                RegistroFinal = response.RegistroFinal,
                RegistroInicial = response.RegistroInicial,
                RegistrosPorPagina = response.RegistrosPorPagina,
                TotalRegistros = response.TotalRegistros,
                Lista = response.Lista.Select(x => PastaDto.New(x)).ToList()
            };
        }
    }
}
