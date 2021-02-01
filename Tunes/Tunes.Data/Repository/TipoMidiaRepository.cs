using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tunes.Business.CollectionFilters;
using Tunes.Business.Interfaces.Repository;
using Tunes.Business.Models;
using Tunes.Data.Context;

namespace Tunes.Data.Repository
{
    public class TipoMidiaRepository : Repository<TipoMidia>, ITipoMidiaRepository
    {
        public TipoMidiaRepository(TunesContext context) : base(context) { }

        public async Task<IList<TipoMidia>> Filtro(TipoMidiaFiltro filtro)
        {
            var tipoMidiaQuery = Db.TiposDeMidia.AsNoTracking();

            if (filtro != null)
            {
                if (!string.IsNullOrEmpty(filtro.Nome))
                    tipoMidiaQuery = tipoMidiaQuery.Where(t => t.Nome.Contains(filtro.Nome));
            }

            return await tipoMidiaQuery.ToListAsync();
        }
    }
}
