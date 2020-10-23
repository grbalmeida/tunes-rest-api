using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tunes.Api.Controllers;
using Tunes.Api.ViewModels;
using Tunes.Business.Interfaces;
using Tunes.Business.Interfaces.Repository;
using Tunes.Business.Interfaces.Services;
using Tunes.Business.Models;

namespace Tunes.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/playlists")]
    public class PlaylistController : MainController
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IPlaylistService _playlistService;
        private readonly IMapper _mapper;

        public PlaylistController(IPlaylistRepository playlistRepository,
                                  IPlaylistService playlistService,
                                  IMapper mapper,
                                  INotifier notifier,
                                  IUser user) : base(notifier, user)
        {
            _playlistRepository = playlistRepository;
            _playlistService = playlistService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IList<PlaylistViewModel>> GetAll()
        {
            return _mapper.Map<IList<PlaylistViewModel>>(await _playlistRepository.ObterTodos());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PlaylistViewModel>> GetById(int id)
        {
            var playlist = await _playlistRepository.ObterPorId(id);

            if (playlist == null)
            {
                return NotFound();
            }

            return _mapper.Map<PlaylistViewModel>(playlist);
        }

        [HttpPost]
        public async Task<ActionResult<PlaylistViewModel>> Add(PlaylistViewModel playlistViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _playlistService.Adicionar(_mapper.Map<Playlist>(playlistViewModel));

            return CustomResponse(playlistViewModel);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<PlaylistViewModel>> Update(int id, PlaylistViewModel playlistViewModel)
        {
            if (id != playlistViewModel.PlaylistId)
            {
                NotifyError("O id informado não é o mesmo que foi informado na query");
                return CustomResponse(playlistViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _playlistService.Atualizar(_mapper.Map<Playlist>(playlistViewModel));

            return CustomResponse(playlistViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PlaylistViewModel>> Delete(int id)
        {
            var playlistViewModel = _mapper.Map<PlaylistViewModel>(await _playlistRepository.ObterPorId(id));

            if (playlistViewModel == null)
            {
                return NotFound();
            }

            await _playlistService.Remover(id);

            return CustomResponse(playlistViewModel);
        }
    }
}
