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
    public class FaixaRepository : Repository<Faixa>, IFaixaRepository
    {
        public FaixaRepository(TunesContext context) : base(context) { }

        public override Task<Faixa> ObterPorId(int id)
        {
            return DbSet
                .Include(f => f.Album)
                .Include(f => f.TipoMidia)
                .Include(f => f.Genero)
                .FirstOrDefaultAsync(f => f.FaixaId == id);
        }

        public override Task<List<Faixa>> ObterTodos()
        {
            return DbSet
                .Include(f => f.Album)
                .Include(f => f.TipoMidia)
                .Include(f => f.Genero)
                .ToListAsync();
        }

        public async Task<IList<Faixa>> Filtro(FaixaFiltro filtro)
        {
            var faixaQuery = Db.Faixas.AsNoTracking();

            if (filtro != null)
            {
                if (!string.IsNullOrEmpty(filtro.Nome))
                    faixaQuery = faixaQuery.Where(f => f.Nome.Contains(filtro.Nome, StringComparison.InvariantCultureIgnoreCase));

                if (!string.IsNullOrEmpty(filtro.Compositor))
                    faixaQuery = faixaQuery.Where(f => f.Compositor.Contains(filtro.Compositor, StringComparison.InvariantCultureIgnoreCase));

                if (!string.IsNullOrEmpty(filtro.Album))
                    faixaQuery = faixaQuery.Where(f => f.Album.Titulo.Contains(filtro.Album, StringComparison.InvariantCultureIgnoreCase));

                if (filtro.TipoDeMidiaId > 0)
                    faixaQuery = faixaQuery.Where(f => f.TipoMidia.TipoMidiaId == filtro.TipoDeMidiaId);

                if (filtro.GeneroId > 0)
                    faixaQuery = faixaQuery.Where(f => f.Genero.GeneroId == filtro.GeneroId);
            }

            return await faixaQuery
                .Include(f => f.Album)
                .Include(f => f.TipoMidia)
                .Include(f => f.Genero)
                .ToListAsync();
        }
    }
}
