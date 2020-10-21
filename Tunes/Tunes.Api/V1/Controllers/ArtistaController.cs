using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tunes.Api.Controllers;
using Tunes.Api.ViewModels;
using Tunes.Business.Interfaces;
using Tunes.Business.Models;

namespace Tunes.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/artistas")]
    public class ArtistaController : MainController
    {
        private readonly IArtistaRepository _artistaRepository;
        private readonly IMapper _mapper;

        public ArtistaController(IArtistaRepository artistaRepository,
                                 IMapper mapper,
                                 INotifier notifier,
                                 IUser user) : base(notifier, user)
        {
            _artistaRepository = artistaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IList<ArtistaViewModel>> GetAll()
        {
            return _mapper.Map<IList<ArtistaViewModel>>(await _artistaRepository.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ArtistaViewModel>> GetById(int id)
        {
            var artista = await _artistaRepository.GetById(id);

            if (artista == null)
            {
                return NotFound();
            }

            return _mapper.Map<ArtistaViewModel>(artista);
        }

        [HttpPost]
        public async Task<ActionResult<ArtistaViewModel>> Add(ArtistaViewModel artistaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _artistaRepository.Add(_mapper.Map<Artista>(artistaViewModel));

            return CustomResponse(artistaViewModel);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ArtistaViewModel>> Update(int id, ArtistaViewModel artistaViewModel)
        {
            if (id != artistaViewModel.ArtistaId)
            {
                NotifyError("O id informado não é o mesmoque foi informado na query");
                return CustomResponse(artistaViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _artistaRepository.Update(_mapper.Map<Artista>(artistaViewModel));

            return CustomResponse(artistaViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ArtistaViewModel>> Delete(int id)
        {
            var artistaViewModel = _mapper.Map<ArtistaViewModel>(await _artistaRepository.GetById(id));
        
            if (artistaViewModel == null)
            {
                return NotFound();
            }

            await _artistaRepository.Remove(id);

            return CustomResponse(artistaViewModel);
        }
    }
}
