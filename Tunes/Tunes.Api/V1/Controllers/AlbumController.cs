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
    [Route("api/v{version:apiVersion}/albuns")]
    public class AlbumController : MainController
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IAlbumService _albumService;
        private readonly IMapper _mapper;

        public AlbumController(IAlbumRepository albumRepository,
                               IAlbumService albumService,
                               IMapper mapper,
                               INotifier notifier,
                               IUser user) : base(notifier, user)
        {
            _albumRepository = albumRepository;
            _albumService = albumService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IList<AlbumViewModel>> GetAll()
        {
            return _mapper.Map<IList<AlbumViewModel>>(await _albumRepository.ObterTodos());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AlbumViewModel>> GetById(int id)
        {
            var album = await _albumRepository.ObterPorId(id);

            if (album == null)
            {
                return NotFound();
            }

            return _mapper.Map<AlbumViewModel>(album);
        }

        [HttpPost]
        public async Task<ActionResult<AlbumViewModel>> Add(AlbumViewModel albumViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _albumService.Adicionar(_mapper.Map<Album>(albumViewModel));

            return CustomResponse(albumViewModel);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<AlbumViewModel>> Update(int id, AlbumViewModel albumViewModel)
        {
            if (id != albumViewModel.AlbumId)
            {
                NotifyError("O id informado não é o mesmo que foi informado na query");
                return CustomResponse(albumViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _albumService.Atualizar(_mapper.Map<Album>(albumViewModel));

            return CustomResponse(albumViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<AlbumViewModel>> Delete(int id)
        {
            var albumViewModel = _mapper.Map<AlbumViewModel>(await _albumRepository.ObterPorId(id));

            if (albumViewModel == null)
            {
                return NotFound();
            }

            await _albumService.Remover(id);

            return CustomResponse(albumViewModel);
        }
    }
}
