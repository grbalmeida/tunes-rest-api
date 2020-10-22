using System.Threading.Tasks;
using Tunes.Business.Models;

namespace Tunes.Business.Interfaces.Repository
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        Task<Funcionario> ObterFuncionario(int id);
    }
}
