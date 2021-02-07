using System.Collections.Generic;
using System.Threading.Tasks;
using Tunes.Business.CollectionFilters;
using Tunes.Business.Models;

namespace Tunes.Business.Interfaces.Repository
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        Task<Funcionario> ObterFuncionario(int id);
        Task<IList<Funcionario>> Filtro(FuncionarioFiltro filtro);
    }
}
