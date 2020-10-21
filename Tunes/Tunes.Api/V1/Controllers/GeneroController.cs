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
    [Route("api/v{version:apiVersion}/generos")]
    public class GeneroController : MainController
    {
        private readonly IGeneroRepository _generoRepository;
        private readonly IGeneroService _generoService;
        private readonly IMapper _mapper;

        public GeneroController(IGeneroRepository generoRepository,
                                IGeneroService generoService,
                                IMapper mapper,
                                INotifier notifier,
                                IUser user) : base(notifier, user)
        {
            _generoRepository = generoRepository;
            _generoService = generoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IList<GeneroViewModel>> GetAll()
        {
            return _mapper.Map<IList<GeneroViewModel>>(await _generoRepository.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GeneroViewModel>> GetById(int id)
        {
            var genero = await _generoRepository.GetById(id);

            if (genero == null)
            {
                return NotFound();
            }

            return _mapper.Map<GeneroViewModel>(genero);
        }

        [HttpPost]
        public async Task<ActionResult<GeneroViewModel>> Add(GeneroViewModel generoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _generoService.Adicionar(_mapper.Map<Genero>(generoViewModel));

            return CustomResponse(generoViewModel);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<GeneroViewModel>> Update(int id, GeneroViewModel generoViewModel)
        {
            if (id != generoViewModel.GeneroId)
            {
                NotifyError("O id informado não é o mesmoque foi informado na query");
                return CustomResponse(generoViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _generoService.Atualizar(_mapper.Map<Genero>(generoViewModel));

            return CustomResponse(generoViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<GeneroViewModel>> Delete(int id)
        {
            var generoViewModel = _mapper.Map<GeneroViewModel>(await _generoRepository.GetById(id));

            if (generoViewModel == null)
            {
                return NotFound();
            }

            await _generoService.Remover(id);

            return CustomResponse(generoViewModel);
        }
    }
}
