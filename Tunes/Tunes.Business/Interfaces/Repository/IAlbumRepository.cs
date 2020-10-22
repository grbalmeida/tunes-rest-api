using System.Threading.Tasks;
using Tunes.Business.Models;

namespace Tunes.Business.Interfaces.Repository
{
    public interface IAlbumRepository : IRepository<Album>
    {
        Task<Album> ObterAlbumFaixas(int id);
    }
}
