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
    [Route("api/v{version:apiVersion}/faixas")]
    public class FaixaController : MainController
    {
        private readonly IFaixaRepository _faixaRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly ITipoMidiaRepository _tipoMidiaRepository;
        private readonly IGeneroRepository _generoRepository;
        private readonly IFaixaService _faixaService;
        private readonly IMapper _mapper;

        public FaixaController(IFaixaRepository faixaRepository,
                               IAlbumRepository albumRepository,
                               ITipoMidiaRepository tipoMidiaRepository,
                               IGeneroRepository generoRepository,
                               IFaixaService faixaService,
                               IMapper mapper,
                               INotifier notifier,
                               IUser user) : base(notifier, user)
        {
            _faixaRepository = faixaRepository;
            _albumRepository = albumRepository;
            _tipoMidiaRepository = tipoMidiaRepository;
            _generoRepository = generoRepository;
            _faixaService = faixaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IList<FaixaViewModel>> GetAll()
        {
            return _mapper.Map<IList<FaixaViewModel>>(await _faixaRepository.ObterTodos());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<FaixaViewModel>> GetById(int id)
        {
            var faixa = await _faixaRepository.ObterPorId(id);

            if (faixa == null)
            {
                return NotFound();
            }

            return _mapper.Map<FaixaViewModel>(faixa);
        }

        [HttpPost]
        public async Task<ActionResult<FaixaViewModel>> Add(FaixaViewModel faixaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var faixa = _mapper.Map<Faixa>(faixaViewModel);

            if (faixaViewModel.Album?.AlbumId > 0)
                faixa.Album = await _albumRepository.ObterPorId(faixaViewModel.Album.AlbumId);

            if (faixaViewModel.TipoMidia?.TipoMidiaId > 0)
                faixa.TipoMidia = await _tipoMidiaRepository.ObterPorId(faixaViewModel.TipoMidia.TipoMidiaId);

            if (faixaViewModel.Genero?.GeneroId > 0)
                faixa.Genero = await _generoRepository.ObterPorId(faixaViewModel.Genero.GeneroId);

            await _faixaService.Adicionar(faixa);

            return CustomResponse(faixaViewModel);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<FaixaViewModel>> Update(int id, FaixaViewModel faixaViewModel)
        {
            if (id != faixaViewModel.FaixaId)
            {
                NotifyError("O id informado não é o mesmo que foi informado na query");
                return CustomResponse(faixaViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var faixa = _mapper.Map<Faixa>(faixaViewModel);

            if (faixaViewModel.Album?.AlbumId > 0)
                faixa.Album = await _albumRepository.ObterPorId(faixaViewModel.Album.AlbumId);

            if (faixaViewModel.TipoMidia?.TipoMidiaId > 0)
                faixa.TipoMidia = await _tipoMidiaRepository.ObterPorId(faixaViewModel.TipoMidia.TipoMidiaId);

            if (faixaViewModel.Genero?.GeneroId > 0)
                faixa.Genero = await _generoRepository.ObterPorId(faixaViewModel.Genero.GeneroId);

            await _faixaService.Atualizar(faixa);

            return CustomResponse(faixaViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<FaixaViewModel>> Delete(int id)
        {
            var faixaViewModel = _mapper.Map<FaixaViewModel>(await _faixaRepository.ObterPorId(id));

            if (faixaViewModel == null)
            {
                return NotFound();
            }

            await _faixaService.Remover(id);

            return CustomResponse(faixaViewModel);
        }
    }
}
