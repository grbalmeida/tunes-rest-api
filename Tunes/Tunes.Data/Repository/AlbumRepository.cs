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
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(TunesContext context) : base(context) { }

        public override Task<Album> ObterPorId(int id)
        {
            return DbSet
                .Include(a => a.Artista)
                .FirstOrDefaultAsync(a => a.AlbumId == id);
        }

        public override Task<List<Album>> ObterTodos()
        {
            return DbSet
                .Include(a => a.Artista)
                .ToListAsync();
        }

        public async Task<Album> ObterAlbumFaixas(int id)
        {
            return await DbSet.Include(a => a.Faixas)
                .FirstOrDefaultAsync(a => a.AlbumId == id);
        }

        public async Task<IList<Album>> Filtro(AlbumFiltro filtro)
        {
            var albumQuery = Db.Albuns.AsNoTracking();

            if (filtro != null)
            {
                if (!string.IsNullOrEmpty(filtro.Titulo))
                    albumQuery = albumQuery.Where(a => a.Titulo.Contains(filtro.Titulo, StringComparison.InvariantCultureIgnoreCase));

                if (!string.IsNullOrEmpty(filtro.Artista))
                    albumQuery = albumQuery.Where(a => a.Artista.Nome.Contains(filtro.Artista, StringComparison.InvariantCultureIgnoreCase));
            }

            return await albumQuery.Include(a => a.Artista).ToListAsync();
        }
    }
}
