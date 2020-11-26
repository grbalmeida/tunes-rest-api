using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Tunes.Business.Interfaces.Repository;
using Tunes.Business.Models;
using Tunes.Data.Context;

namespace Tunes.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(TunesContext context) : base(context) { }

        public async override Task<Cliente> ObterPorId(int id)
        {
            return await DbSet
                .Include(c => c.Suporte)
                .FirstOrDefaultAsync(c => c.ClienteId == id);
        }
    }
}
