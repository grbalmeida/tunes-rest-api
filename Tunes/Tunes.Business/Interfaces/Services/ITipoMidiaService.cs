using System;
using System.Threading.Tasks;
using Tunes.Business.Models;

namespace Tunes.Business.Interfaces.Services
{
    public interface ITipoMidiaService : IDisposable
    {
        Task<bool> Adicionar(TipoMidia tipoMidia);
        Task<bool> Atualizar(TipoMidia tipoMidia);
        Task<bool> Remover(int id);
    }
}
