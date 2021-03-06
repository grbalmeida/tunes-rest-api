﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tunes.Api.Controllers;
using Tunes.Api.ViewModels;
using Tunes.Business.Interfaces.Repository;
using Tunes.Business.Interfaces;
using Tunes.Business.Models;
using Tunes.Business.Interfaces.Services;

namespace Tunes.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/artistas")]
    public class ArtistaController : MainController
    {
        private readonly IArtistaRepository _artistaRepository;
        private readonly IArtistaService _artistaService;
        private readonly IMapper _mapper;

        public ArtistaController(IArtistaRepository artistaRepository,
                                 IArtistaService artistaService,
                                 IMapper mapper,
                                 INotifier notifier,
                                 IUser user) : base(notifier, user)
        {
            _artistaRepository = artistaRepository;
            _artistaService = artistaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IList<ArtistaViewModel>> GetAll()
        {
            return _mapper.Map<IList<ArtistaViewModel>>(await _artistaRepository.ObterTodos());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ArtistaViewModel>> GetById(int id)
        {
            var artista = await _artistaRepository.ObterPorId(id);

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

            await _artistaService.Adicionar(_mapper.Map<Artista>(artistaViewModel));

            return CustomResponse(artistaViewModel);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ArtistaViewModel>> Update(int id, ArtistaViewModel artistaViewModel)
        {
            if (id != artistaViewModel.ArtistaId)
            {
                NotifyError("O id informado não é o mesmo que foi informado na query");
                return CustomResponse(artistaViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _artistaService.Atualizar(_mapper.Map<Artista>(artistaViewModel));

            return CustomResponse(artistaViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ArtistaViewModel>> Delete(int id)
        {
            var artistaViewModel = _mapper.Map<ArtistaViewModel>(await _artistaRepository.ObterPorId(id));
        
            if (artistaViewModel == null)
            {
                return NotFound();
            }

            await _artistaService.Remover(id);

            return CustomResponse(artistaViewModel);
        }
    }
}
