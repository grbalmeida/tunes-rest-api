using System.Collections.Generic;
using System.Threading.Tasks;
using Tunes.Business.CollectionFilters;
using Tunes.Business.Models;

namespace Tunes.Business.Interfaces.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<IList<Cliente>> Filtro(ClienteFiltro filtro);
    }
}
