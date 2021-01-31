using System.Collections.Generic;
using System.Threading.Tasks;
using Tunes.Business.CollectionFilters;
using Tunes.Business.Models;

namespace Tunes.Business.Interfaces.Repository
{
    public interface IPlaylistRepository : IRepository<Playlist>
    {
        Task<IList<Playlist>> Filtro(PlaylistFiltro filtro);
    }
}
