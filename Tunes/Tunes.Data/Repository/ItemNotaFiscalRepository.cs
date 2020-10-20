using Tunes.Business.Interfaces;
using Tunes.Business.Models;
using Tunes.Data.Context;

namespace Tunes.Data.Repository
{
    public class ItemNotaFiscalRepository : Repository<ItemNotaFiscal>, IItemNotaFiscalRepository
    {
        public ItemNotaFiscalRepository(TunesContext context) : base(context) { }
    }
}
