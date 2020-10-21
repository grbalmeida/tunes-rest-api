using System.Threading.Tasks;
using Tunes.Business.Models;

namespace Tunes.Business.Interfaces.Repository
{
    public interface IGeneroRepository : IRepository<Genero>
    {
        Task<Genero> ObterGeneroFaixas(int id);
    }
}
