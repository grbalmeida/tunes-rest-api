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
        private readonly IFaixaService _faixaService;
        private readonly IMapper _mapper;

        public FaixaController(IFaixaRepository faixaRepository,
                               IFaixaService faixaService,
                               IMapper mapper,
                               INotifier notifier,
                               IUser user) : base(notifier, user)
        {
            _faixaRepository = faixaRepository;
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

            await _faixaService.Adicionar(_mapper.Map<Faixa>(faixaViewModel));

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

            await _faixaService.Atualizar(_mapper.Map<Faixa>(faixaViewModel));

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
