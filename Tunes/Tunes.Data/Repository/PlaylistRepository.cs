using Tunes.Business.Interfaces.Repository;
using Tunes.Business.Models;
using Tunes.Data.Context;

namespace Tunes.Data.Repository
{
    public class PlaylistRepository : Repository<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(TunesContext context) : base(context) { }
    }
}
