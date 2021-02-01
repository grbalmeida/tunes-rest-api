using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tunes.Business.CollectionFilters;
using Tunes.Business.Interfaces.Repository;
using Tunes.Business.Models;
using Tunes.Data.Context;

namespace Tunes.Data.Repository
{
    public class PlaylistRepository : Repository<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(TunesContext context) : base(context) { }

        public async Task<IList<Playlist>> Filtro(PlaylistFiltro filtro)
        {
            var playlistQuery = Db.Playlists.AsNoTracking();

            if (filtro != null)
            {
                if (!string.IsNullOrEmpty(filtro.Nome))
                    playlistQuery = playlistQuery.Where(p => p.Nome.Contains(filtro.Nome));
            }

            return await playlistQuery.ToListAsync();
        }
    }
}
