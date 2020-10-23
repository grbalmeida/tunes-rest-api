using DevIO.Business.Services;
using System.Threading.Tasks;
using Tunes.Business.Interfaces;
using Tunes.Business.Interfaces.Repository;
using Tunes.Business.Interfaces.Services;
using Tunes.Business.Models;
using Tunes.Business.Models.Validations;

namespace Tunes.Business.Services
{
    public class PlaylistService : BaseService, IPlaylistService
    {
        private readonly IPlaylistRepository _playlistRepository;

        public PlaylistService(IPlaylistRepository playlistRepository, INotifier notificador) : base(notificador)
        {
            _playlistRepository = playlistRepository;
        }

        public async Task<bool> Adicionar(Playlist playlist)
        {
            if (!ExecutarValidacao(new PlaylistValidation(), playlist)) return false;

            await _playlistRepository.Adicionar(playlist);

            return true;
        }

        public async Task<bool> Atualizar(Playlist playlist)
        {
            if (!ExecutarValidacao(new PlaylistValidation(), playlist)) return false;

            await _playlistRepository.Atualizar(playlist);

            return true;
        }

        public async Task<bool> Remover(int id)
        {
            await _playlistRepository.Remover(id);

            return true;
        }

        public void Dispose()
        {
            _playlistRepository?.Dispose();
        }
    }
}
