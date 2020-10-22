using System;
using System.Threading.Tasks;
using Tunes.Business.Models;

namespace Tunes.Business.Interfaces.Services
{
    public interface IClienteService : IDisposable
    {
        Task<bool> Adicionar(Cliente cliente);
        Task<bool> Atualizar(Cliente cliente);
        Task<bool> Remover(int id);
    }
}
