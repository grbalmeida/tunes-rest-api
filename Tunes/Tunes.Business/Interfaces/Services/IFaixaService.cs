using System;
using System.Threading.Tasks;
using Tunes.Business.Models;

namespace Tunes.Business.Interfaces.Services
{
    public interface IFaixaService : IDisposable
    {
        Task<bool> Adicionar(Faixa faixa);
        Task<bool> Atualizar(Faixa faixa);
        Task<bool> Remover(int id);
    }
}
