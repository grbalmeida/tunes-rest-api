using System;
using System.Threading.Tasks;
using Tunes.Business.Models;

namespace Tunes.Business.Interfaces.Services
{
    public interface IArtistaService : IDisposable
    {
        Task<bool> Adicionar(Artista artista);
        Task<bool> Atualizar(Artista artista);
        Task<bool> Remover(int id);
    }
}
