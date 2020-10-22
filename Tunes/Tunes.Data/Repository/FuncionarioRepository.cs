using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Tunes.Business.Interfaces.Repository;
using Tunes.Business.Models;
using Tunes.Data.Context;

namespace Tunes.Data.Repository
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(TunesContext context) : base(context) { }

        public async Task<Funcionario> ObterFuncionario(int id)
        {
            return await DbSet.Include(f => f.Equipe)
                .Include(f => f.ClientesAtendidos)
                .FirstOrDefaultAsync(f => f.FuncionarioId == id);
        }
    }
}
