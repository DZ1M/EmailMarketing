using EmailMarketing.Architecture.Core.Domain;
using EmailMarketing.Domain.Entities;

namespace EmailMarketing.Domain.Interfaces
{
    public interface IPastaRepository : IRepositoryBase<Pasta>
    {
        Task<ListaPaginada<Pasta>> ListPaginada(int length, int start, string? search, string? sortColumn, string? sortColumnDirection);
    }
}
