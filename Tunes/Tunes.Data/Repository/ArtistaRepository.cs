using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Tunes.Business.Interfaces.Repository;
using Tunes.Business.Models;
using Tunes.Data.Context;

namespace Tunes.Data.Repository
{
    public class ArtistaRepository : Repository<Artista>, IArtistaRepository
    {
        public ArtistaRepository(TunesContext context) : base(context) { }

        public async Task<Artista> ObterArtistaAlbuns(int id)
        {
            return await Db.Artistas.AsNoTracking()
                .Include(a => a.Albuns)
                .FirstOrDefaultAsync(a => a.ArtistaId == id);
        }
    }
}
