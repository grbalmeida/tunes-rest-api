using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Tunes.Business.Interfaces.Repository;
using Tunes.Business.Models;
using Tunes.Data.Context;

namespace Tunes.Data.Repository
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(TunesContext context) : base(context) { }

        public async Task<Album> ObterAlbumFaixas(int id)
        {
            return await DbSet.Include(a => a.Faixas)
                .FirstOrDefaultAsync(a => a.AlbumId == id);
        }
    }
}
