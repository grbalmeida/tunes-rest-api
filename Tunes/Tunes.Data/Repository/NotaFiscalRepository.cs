using Tunes.Business.Interfaces.Repository;
using Tunes.Business.Models;
using Tunes.Data.Context;

namespace Tunes.Data.Repository
{
    public class NotaFiscalRepository : Repository<NotaFiscal>, INotaFiscalRepository
    {
        public NotaFiscalRepository(TunesContext context) : base(context) { }
    }
}
