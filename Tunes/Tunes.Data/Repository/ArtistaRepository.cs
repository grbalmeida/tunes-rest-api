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
    public class ArtistaRepository : Repository<Artista>, IArtistaRepository
    {
        public ArtistaRepository(TunesContext context) : base(context) { }

        public async Task<Artista> ObterArtistaAlbuns(int id)
        {
            return await Db.Artistas.AsNoTracking()
                .Include(a => a.Albuns)
                .FirstOrDefaultAsync(a => a.ArtistaId == id);
        }

        public async Task<IList<Artista>> Filtro(ArtistaFiltro filtro)
        {
            var artistaQuery = Db.Artistas.AsNoTracking();

            if (filtro != null)
            {
                if (!string.IsNullOrEmpty(filtro.Nome))
                    artistaQuery = artistaQuery.Where(a => a.Nome.Contains(filtro.Nome));
            }

            return await artistaQuery.ToListAsync();
        }
    }
}
