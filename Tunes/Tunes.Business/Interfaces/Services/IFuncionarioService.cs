using System;
using System.Threading.Tasks;
using Tunes.Business.Models;

namespace Tunes.Business.Interfaces.Services
{
    public interface IFuncionarioService : IDisposable
    {
        Task<bool> Adicionar(Funcionario funcionario);
        Task<bool> Atualizar(Funcionario funcionario);
        Task<bool> Remover(int id);
    }
}
