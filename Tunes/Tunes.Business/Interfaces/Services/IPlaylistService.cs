using System;
using System.Threading.Tasks;
using Tunes.Business.Models;

namespace Tunes.Business.Interfaces.Services
{
    public interface IPlaylistService : IDisposable
    {
        Task<bool> Adicionar(Playlist playlist);
        Task<bool> Atualizar(Playlist playlist);
        Task<bool> Remover(int id);
    }
}
