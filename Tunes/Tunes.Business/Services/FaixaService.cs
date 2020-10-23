using DevIO.Business.Services;
using System.Threading.Tasks;
using Tunes.Business.Interfaces;
using Tunes.Business.Interfaces.Repository;
using Tunes.Business.Interfaces.Services;
using Tunes.Business.Models;
using Tunes.Business.Models.Validations;

namespace Tunes.Business.Services
{
    public class FaixaService : BaseService, IFaixaService
    {
        private readonly IFaixaRepository _faixaRepository;

        public FaixaService(IFaixaRepository faixaRepository, INotifier notifier) : base(notifier)
        {
            _faixaRepository = faixaRepository;
        }

        public async Task<bool> Adicionar(Faixa faixa)
        {
            if (!ExecutarValidacao(new FaixaValidation(), faixa)) return false;

            await _faixaRepository.Adicionar(faixa);

            return true;
        }

        public async Task<bool> Atualizar(Faixa faixa)
        {
            if (!ExecutarValidacao(new FaixaValidation(), faixa)) return false;

            await _faixaRepository.Atualizar(faixa);

            return true;
        }

        public async Task<bool> Remover(int id)
        {
            await _faixaRepository.Remover(id);

            return true;
        }

        public void Dispose()
        {
            _faixaRepository?.Dispose();
        }
    }
}
