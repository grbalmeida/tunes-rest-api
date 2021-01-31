using System.Collections.Generic;
using System.Threading.Tasks;
using Tunes.Business.CollectionFilters;
using Tunes.Business.Models;

namespace Tunes.Business.Interfaces.Repository
{
    public interface IGeneroRepository : IRepository<Genero>
    {
        Task<Genero> ObterGeneroFaixas(int id);
        Task<IList<Genero>> Filtro(GeneroFiltro filtro);
    }
}
