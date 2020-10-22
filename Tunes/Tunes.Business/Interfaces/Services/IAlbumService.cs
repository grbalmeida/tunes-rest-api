using System;
using System.Threading.Tasks;
using Tunes.Business.Models;

namespace Tunes.Business.Interfaces.Services
{
    public interface IAlbumService : IDisposable
    {
        Task<bool> Adicionar(Album album);
        Task<bool> Atualizar(Album album);
        Task<bool> Remover(int id);
    }
}
