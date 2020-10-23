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
    public class AlbumService : BaseService, IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository, INotifier notifier) : base(notifier)
        {
            _albumRepository = albumRepository;
        }

        public async Task<bool> Adicionar(Album album)
        {
            if (!ExecutarValidacao(new AlbumValidation(), album)) return false;

            await _albumRepository.Adicionar(album);

            return true;
        }

        public async Task<bool> Atualizar(Album album)
        {
            if (!ExecutarValidacao(new AlbumValidation(), album)) return false;

            await _albumRepository.Atualizar(album);

            return true;
        }

        public async Task<bool> Remover(int id)
        {
            var album = await _albumRepository.ObterAlbumFaixas(id);

            if (album.Faixas.Any())
            {
                Notificar("O álbum possui faixas cadastradas!");
                return false;
            }

            await _albumRepository.Remover(id);

            return true;
        }

        public void Dispose()
        {
            _albumRepository?.Dispose();
        }
    }
}
