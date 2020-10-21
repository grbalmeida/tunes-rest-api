using Tunes.Business.Interfaces.Repository;
using Tunes.Business.Models;
using Tunes.Data.Context;

namespace Tunes.Data.Repository
{
    public class PlaylistFaixaRepository : Repository<PlaylistFaixa>, IPlaylistFaixaRepository
    {
        public PlaylistFaixaRepository(TunesContext context) : base(context) { }
    }
}
