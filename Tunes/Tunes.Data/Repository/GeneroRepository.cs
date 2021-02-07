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
    public class GeneroRepository : Repository<Genero>, IGeneroRepository
    {
        public GeneroRepository(TunesContext context) : base(context) { }

        public async Task<Genero> ObterGeneroFaixas(int id)
        {
            return await DbSet.AsNoTracking()
                .Include(g => g.Faixas)
                .FirstOrDefaultAsync(g => g.GeneroId == id);
        }

        public async Task<IList<Genero>> Filtro(GeneroFiltro filtro)
        {
            var generoQuery = DbSet.AsNoTracking();

            if (filtro != null)
            {
                if (!string.IsNullOrEmpty(filtro.Nome))
                    generoQuery = generoQuery.Where(g => g.Nome.Contains(filtro.Nome));
            }

            return await generoQuery.ToListAsync();
        }
    }
}
