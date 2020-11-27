using System.Threading.Tasks;
using Tunes.Business.Models;

namespace Tunes.Business.Interfaces.Repository
{
    public interface IItemNotaFiscalRepository : IRepository<ItemNotaFiscal>
    {
        Task RemoverPorNotaFiscalId(int notaFiscalId);
    }
}
