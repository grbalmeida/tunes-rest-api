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
    public class ArtistaService : BaseService, IArtistaService
    {
        private readonly IArtistaRepository _artistaRepository;

        public ArtistaService(IArtistaRepository artistaRepository, INotifier notificador) : base(notificador)
        {
            _artistaRepository = artistaRepository;
        }

        public async Task<bool> Adicionar(Artista artista)
        {
            if (!ExecutarValidacao(new ArtistaValidation(), artista)) return false;

            await _artistaRepository.Add(artista);

            return true;
        }

        public async Task<bool> Atualizar(Artista artista)
        {
            if (!ExecutarValidacao(new ArtistaValidation(), artista)) return false;

            await _artistaRepository.Update(artista);

            return true;
        }

        public async Task<bool> Remover(int id)
        {
            if (_artistaRepository.ObterArtistaAlbuns(id).Result.Albuns.Any())
            {
                Notificar("O artista possui álbuns cadastrados!");
                return false;
            }

            await _artistaRepository.Remove(id);

            return true;
        }

        public void Dispose()
        {
            _artistaRepository?.Dispose();
        }
    }
}
