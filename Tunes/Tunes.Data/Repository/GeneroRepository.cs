using Tunes.Business.Interfaces.Repository;
using Tunes.Business.Models;
using Tunes.Data.Context;

namespace Tunes.Data.Repository
{
    public class GeneroRepository : Repository<Genero>, IGeneroRepository
    {
        public GeneroRepository(TunesContext context) : base(context) { }
    }
}
