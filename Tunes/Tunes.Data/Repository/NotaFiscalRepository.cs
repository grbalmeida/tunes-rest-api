using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tunes.Business.Interfaces.Repository;
using Tunes.Business.Models;
using Tunes.Data.Context;

namespace Tunes.Data.Repository
{
    public class NotaFiscalRepository : Repository<NotaFiscal>, INotaFiscalRepository
    {
        public NotaFiscalRepository(TunesContext context) : base(context) { }

        public override async Task<IEnumerable<NotaFiscal>> Busca(Expression<Func<NotaFiscal, bool>> predicate)
        {
            return await DbSet.AsNoTracking()
                .Where(predicate)
                .Include(nf => nf.Cliente)
                .Include(nf => nf.ItensNotaFiscal)
                .ToListAsync();
        }

        public override async Task<NotaFiscal> ObterPorId(int id)
        {
            return await DbSet.Where(nf => nf.NotaFiscalId == id)
                .Include(nf => nf.Cliente)
                .Include(nf => nf.ItensNotaFiscal)
                .FirstOrDefaultAsync();
        }

        public override async Task<List<NotaFiscal>> ObterTodos()
        {
            return await DbSet.Include(nf => nf.Cliente)
                .Include(nf => nf.ItensNotaFiscal)
                .ToListAsync();
        }
    }
}
