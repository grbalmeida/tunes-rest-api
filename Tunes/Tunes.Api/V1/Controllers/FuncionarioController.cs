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
    [Route("api/v{version:apiVersion}/funcionarios")]
    public class FuncionarioController : MainController
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IFuncionarioService _funcionarioService;
        private readonly IMapper _mapper;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository,
                                     IFuncionarioService funcionarioService,
                                     IMapper mapper,
                                     INotifier notifier,
                                     IUser user) : base(notifier, user)
        {
            _funcionarioRepository = funcionarioRepository;
            _funcionarioService = funcionarioService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IList<FuncionarioViewModel>> GetAll()
        {
            return _mapper.Map<IList<FuncionarioViewModel>>(await _funcionarioRepository.ObterTodos());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<FuncionarioViewModel>> GetById(int id)
        {
            var funcionario = await _funcionarioRepository.ObterPorId(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return _mapper.Map<FuncionarioViewModel>(funcionario);
        }

        [HttpPost]
        public async Task<ActionResult<FuncionarioViewModel>> Add(FuncionarioViewModel funcionarioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _funcionarioService.Adicionar(_mapper.Map<Funcionario>(funcionarioViewModel));

            return CustomResponse(funcionarioViewModel);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<FuncionarioViewModel>> Update(int id, FuncionarioViewModel funcionarioViewModel)
        {
            if (id != funcionarioViewModel.FuncionarioId)
            {
                NotifyError("O id informado não é o mesmo que foi informado na query");
                return CustomResponse(funcionarioViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _funcionarioService.Atualizar(_mapper.Map<Funcionario>(funcionarioViewModel));

            return CustomResponse(funcionarioViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<FuncionarioViewModel>> Delete(int id)
        {
            var funcionarioViewModel = _mapper.Map<FuncionarioViewModel>(await _funcionarioRepository.ObterPorId(id));

            if (funcionarioViewModel == null)
            {
                return NotFound();
            }

            await _funcionarioService.Remover(id);

            return CustomResponse(funcionarioViewModel);
        }
    }
}
