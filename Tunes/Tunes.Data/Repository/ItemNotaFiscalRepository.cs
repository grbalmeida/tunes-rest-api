using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Tunes.Business.Interfaces.Repository;
using Tunes.Business.Models;
using Tunes.Data.Context;

namespace Tunes.Data.Repository
{
    public class ItemNotaFiscalRepository : Repository<ItemNotaFiscal>, IItemNotaFiscalRepository
    {
        public ItemNotaFiscalRepository(TunesContext context) : base(context) { }

        public async Task RemoverPorNotaFiscalId(int notaFiscalId)
        {
            var entities = await DbSet.Where(inf => inf.NotaFiscal.NotaFiscalId == notaFiscalId).ToListAsync();

            DbSet.RemoveRange(entities);
            await SalvarAlteracoes();
        }
    }
}
