using DevIO.Business.Services;
using System.Threading.Tasks;
using Tunes.Business.Interfaces;
using Tunes.Business.Interfaces.Repository;
using Tunes.Business.Interfaces.Services;
using Tunes.Business.Models;
using Tunes.Business.Models.Validations;

namespace Tunes.Business.Services
{
    public class TipoMidiaService : BaseService, ITipoMidiaService
    {
        private readonly ITipoMidiaRepository _tipoMidiaRepository;

        public TipoMidiaService(ITipoMidiaRepository tipoMidiaRepository, INotifier notificador) : base(notificador)
        {
            _tipoMidiaRepository = tipoMidiaRepository;
        }

        public async Task<bool> Adicionar(TipoMidia tipoMidia)
        {
            if (!ExecutarValidacao(new TipoMidiaValidation(), tipoMidia)) return false;

            await _tipoMidiaRepository.Adicionar(tipoMidia);

            return true;
        }

        public async Task<bool> Atualizar(TipoMidia tipoMidia)
        {
            if (!ExecutarValidacao(new TipoMidiaValidation(), tipoMidia)) return false;

            await _tipoMidiaRepository.Atualizar(tipoMidia);

            return true;
        }

        public async Task<bool> Remover(int id)
        {
            await _tipoMidiaRepository.Remover(id);

            return true;
        }

        public void Dispose()
        {
            _tipoMidiaRepository?.Dispose();
        }
    }
}
