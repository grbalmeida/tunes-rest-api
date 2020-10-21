using Tunes.Business.Interfaces.Repository;
using Tunes.Business.Models;
using Tunes.Data.Context;

namespace Tunes.Data.Repository
{
    public class TipoMidiaRepository : Repository<TipoMidia>, ITipoMidiaRepository
    {
        public TipoMidiaRepository(TunesContext context) : base(context) { }
    }
}
