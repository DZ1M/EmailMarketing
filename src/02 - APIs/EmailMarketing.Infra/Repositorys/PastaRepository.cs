using EmailMarketing.Architecture.Core.Domain;
using EmailMarketing.Architecture.Helpers;
using EmailMarketing.Domain.Entities;
using EmailMarketing.Domain.Interfaces;
using EmailMarketing.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace EmailMarketing.Infra.Repositorys
{
    public class PastaRepository : RepositoryBase<Pasta>, IPastaRepository
    {
        public PastaRepository(EmailMarketingContext context) : base(context)
        {
        }
        public async Task<ListaPaginada<Pasta>> ListPaginada(int length, int start, string? search, string? sortColumn, string? sortColumnDirection)
        {
            search ??= string.Empty;

            var result = new ListaPaginada<Pasta>
            {
                Query = search,
                RegistrosPorPagina = length,
                Pagina = start,
                TotalRegistros = await _context.Pastas.AsQueryable().AsNoTrackingWithIdentityResolution()
                                            .Where(x => EF.Functions.ILike(EF.Functions.Unaccent(x.Nome), $"%{search.Replace(" ", "%")}%"))
                                            .CountAsync(),
                Lista = _context.Pastas.AsQueryable().AsNoTrackingWithIdentityResolution()
                                            .Where(x => EF.Functions.ILike(EF.Functions.Unaccent(x.Nome), $"%{search.Replace(" ", "%")}%"))
                                            .FiltrarPaginado(start, length, sortColumn, sortColumnDirection).ToList()
            };

            result.CalcularRegistros();

            return result;
        }
    }
}
