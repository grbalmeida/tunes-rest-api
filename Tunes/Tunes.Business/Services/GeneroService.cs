using DevIO.Business.Services;
using System.Linq;
using System.Threading.Tasks;
using Tunes.Business.Interfaces;
using Tunes.Business.Interfaces.Repository;
using Tunes.Business.Interfaces.Services;
using Tunes.Business.Models;
using Tunes.Business.Models.Validations;

namespace Tunes.Business.Services
{
    public class GeneroService : BaseService, IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroService(IGeneroRepository generoRepository, INotifier notificador) : base(notificador)
        {
            _generoRepository = generoRepository;
        }

        public async Task<bool> Adicionar(Genero genero)
        {
            if (!ExecutarValidacao(new GeneroValidation(), genero)) return false;

            await _generoRepository.Add(genero);

            return true;
        }

        public async Task<bool> Atualizar(Genero genero)
        {
            if (!ExecutarValidacao(new GeneroValidation(), genero)) return false;

            await _generoRepository.Update(genero);

            return true;
        }

        public async Task<bool> Remover(int id)
        {
            if (_generoRepository.ObterGeneroFaixas(id).Result.Faixas.Any())
            {
                Notificar("O gênero possui faixas cadastradas!");
                return false;
            }

            await _generoRepository.Remove(id);

            return true;
        }

        public void Dispose()
        {
            _generoRepository?.Dispose();
        }
    }
}
