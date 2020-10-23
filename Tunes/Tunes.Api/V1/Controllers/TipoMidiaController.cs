using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections;
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
    [Route("api/v{version:apiVersion}/tipos-de-midia")]
    public class TipoMidiaController : MainController
    {
        private readonly ITipoMidiaRepository _tipoMidiaRepository;
        private readonly ITipoMidiaService _tipoMidiaService;
        private readonly IMapper _mapper;

        public TipoMidiaController(ITipoMidiaRepository tipoMidiaRepository,
                                   ITipoMidiaService tipoMidiaService,
                                   IMapper mapper,
                                   INotifier notifier,
                                   IUser user) : base(notifier, user)
        {
            _tipoMidiaRepository = tipoMidiaRepository;
            _tipoMidiaService = tipoMidiaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IList<TipoMidiaViewModel>> GetAll()
        {
            return _mapper.Map<IList<TipoMidiaViewModel>>(await _tipoMidiaRepository.ObterTodos());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TipoMidiaViewModel>> GetById(int id)
        {
            var tipoMidia = await _tipoMidiaRepository.ObterPorId(id);

            if (tipoMidia == null)
            {
                return NotFound();
            }

            return _mapper.Map<TipoMidiaViewModel>(tipoMidia);
        }

        [HttpPost]
        public async Task<ActionResult<TipoMidiaViewModel>> Add(TipoMidiaViewModel tipoMidiaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _tipoMidiaService.Adicionar(_mapper.Map<TipoMidia>(tipoMidiaViewModel));

            return CustomResponse(tipoMidiaViewModel);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TipoMidiaViewModel>> Update(int id, TipoMidiaViewModel tipoMidiaViewModel)
        {
            if (id != tipoMidiaViewModel.TipoMidiaId)
            {
                NotifyError("O id informado não é o mesmo que foi informado na query");
                return CustomResponse(tipoMidiaViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _tipoMidiaService.Atualizar(_mapper.Map<TipoMidia>(tipoMidiaViewModel));

            return CustomResponse(tipoMidiaViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TipoMidiaViewModel>> Delete(int id)
        {
            var tipoMidiaViewModel = _mapper.Map<TipoMidiaViewModel>(await _tipoMidiaRepository.ObterPorId(id));

            if (tipoMidiaViewModel == null)
            {
                return NotFound();
            }

            await _tipoMidiaService.Remover(id);

            return CustomResponse(tipoMidiaViewModel);
        }
    }
}
