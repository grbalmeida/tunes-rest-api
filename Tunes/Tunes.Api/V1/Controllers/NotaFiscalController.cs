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
    [Route("api/v{version:apiVersion}/notas-fiscais")]
    public class NotaFiscalController : MainController
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;
        private readonly INotaFiscalService _notaFiscalService;
        private readonly IMapper _mapper;

        public NotaFiscalController(INotaFiscalRepository notaFiscalRepository,
                                    INotaFiscalService notaFiscalService,
                                    IMapper mapper,
                                    INotifier notifier,
                                    IUser user) : base(notifier, user)
        {
            _notaFiscalRepository = notaFiscalRepository;
            _notaFiscalService = notaFiscalService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IList<NotaFiscalViewModel>> GetAll()
        {
            return _mapper.Map<IList<NotaFiscalViewModel>>(await _notaFiscalRepository.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<NotaFiscalViewModel>> GetById(int id)
        {
            var notaFiscal = await _notaFiscalRepository.GetById(id);

            if (notaFiscal == null)
            {
                return NotFound();
            }

            return _mapper.Map<NotaFiscalViewModel>(notaFiscal);
        }

        [HttpPost]
        public async Task<ActionResult<NotaFiscalViewModel>> Add(NotaFiscalViewModel notaFiscalViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _notaFiscalService.Adicionar(_mapper.Map<NotaFiscal>(notaFiscalViewModel));

            return CustomResponse(notaFiscalViewModel);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<NotaFiscalViewModel>> Update(int id, NotaFiscalViewModel notaFiscalViewModel)
        {
            if (id != notaFiscalViewModel.NotaFiscalId)
            {
                NotifyError("O id informado não é o mesmo que foi informado na query");
                return CustomResponse(notaFiscalViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _notaFiscalService.Atualizar(_mapper.Map<NotaFiscal>(notaFiscalViewModel));

            return CustomResponse(notaFiscalViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<NotaFiscalViewModel>> Delete(int id)
        {
            var notaFiscalViewModel = _mapper.Map<NotaFiscalViewModel>(await _notaFiscalRepository.GetById(id));

            if (notaFiscalViewModel == null)
            {
                return NotFound();
            }

            await _notaFiscalService.Remover(id);

            return CustomResponse(notaFiscalViewModel);
        }
    }
}
