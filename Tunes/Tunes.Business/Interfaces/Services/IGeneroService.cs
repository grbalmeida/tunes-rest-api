using System;
using System.Threading.Tasks;
using Tunes.Business.Models;

namespace Tunes.Business.Interfaces.Services
{
    public interface IGeneroService : IDisposable
    {
        Task<bool> Adicionar(Genero genero);
        Task<bool> Atualizar(Genero genero);
        Task<bool> Remover(int id);
    }
}
