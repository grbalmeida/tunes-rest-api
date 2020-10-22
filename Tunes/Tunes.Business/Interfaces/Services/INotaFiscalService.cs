using System;
using System.Threading.Tasks;
using Tunes.Business.Models;

namespace Tunes.Business.Interfaces.Services
{
    public interface INotaFiscalService : IDisposable
    {
        Task<bool> Adicionar(NotaFiscal notaFiscal);
        Task<bool> Atualizar(NotaFiscal notaFiscal);
        Task<bool> Remover(int id);
    }
}
