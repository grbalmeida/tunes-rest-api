using DevIO.Business.Services;
using System.Threading.Tasks;
using Tunes.Business.Interfaces;
using Tunes.Business.Interfaces.Repository;
using Tunes.Business.Interfaces.Services;
using Tunes.Business.Models;
using Tunes.Business.Models.Validations;

namespace Tunes.Business.Services
{
    public class NotaFiscalService : BaseService, INotaFiscalService
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;

        public NotaFiscalService(INotaFiscalRepository notaFiscalRepository, INotifier notificador) : base(notificador)
        {
            _notaFiscalRepository = notaFiscalRepository;
        }

        public async Task<bool> Adicionar(NotaFiscal notaFiscal)
        {
            if (!ExecutarValidacao(new NotaFiscalValidation(), notaFiscal)) return false;

            await _notaFiscalRepository.Add(notaFiscal);

            return true;
        }

        public async Task<bool> Atualizar(NotaFiscal notaFiscal)
        {
            if (!ExecutarValidacao(new NotaFiscalValidation(), notaFiscal)) return false;

            await _notaFiscalRepository.Update(notaFiscal);

            return true;
        }

        public async Task<bool> Remover(int id)
        {
            await _notaFiscalRepository.Remove(id);

            return true;
        }

        public void Dispose()
        {
            _notaFiscalRepository?.Dispose();
        }
    }
}
