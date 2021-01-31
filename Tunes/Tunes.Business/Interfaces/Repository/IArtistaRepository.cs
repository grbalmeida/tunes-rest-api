using System.Collections.Generic;
using System.Threading.Tasks;
using Tunes.Business.CollectionFilters;
using Tunes.Business.Models;

namespace Tunes.Business.Interfaces.Repository
{
    public interface IArtistaRepository : IRepository<Artista>
    {
        Task<Artista> ObterArtistaAlbuns(int id);
        Task<IList<Artista>> Filtro(ArtistaFiltro filtro);
    }
}
