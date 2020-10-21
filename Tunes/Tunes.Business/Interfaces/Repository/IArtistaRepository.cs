using System.Threading.Tasks;
using Tunes.Business.Models;

namespace Tunes.Business.Interfaces.Repository
{
    public interface IArtistaRepository : IRepository<Artista>
    {
        Task<Artista> ObterArtistaAlbuns(int id);
    }
}
