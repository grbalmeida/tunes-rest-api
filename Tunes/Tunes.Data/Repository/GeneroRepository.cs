using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
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
            return await Db.Generos.AsNoTracking()
                .Include(g => g.Faixas)
                .FirstOrDefaultAsync(g => g.GeneroId == id);
        }
    }
}
