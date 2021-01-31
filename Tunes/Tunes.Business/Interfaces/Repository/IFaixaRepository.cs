using System.Collections.Generic;
using System.Threading.Tasks;
using Tunes.Business.CollectionFilters;
using Tunes.Business.Models;

namespace Tunes.Business.Interfaces.Repository
{
    public interface IFaixaRepository : IRepository<Faixa>
    {
        Task<IList<Faixa>> Filtro(FaixaFiltro filtro);
    }
}
