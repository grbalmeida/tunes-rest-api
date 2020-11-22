using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    }
}
