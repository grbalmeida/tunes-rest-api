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
    [Route("api/v{version:apiVersion}/clientes")]
    public class ClienteController : MainController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteRepository clienteRepository,
                                 IClienteService clienteService,
                                 IMapper mapper,
                                 INotifier notifier,
                                 IUser user) : base(notifier, user)
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IList<ClienteViewModel>> GetAll()
        {
            return _mapper.Map<IList<ClienteViewModel>>(await _clienteRepository.ObterTodos());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ClienteViewModel>> GetById(int id)
        {
            var cliente = await _clienteRepository.ObterPorId(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return _mapper.Map<ClienteViewModel>(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<ClienteViewModel>> Add(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _clienteService.Adicionar(_mapper.Map<Cliente>(clienteViewModel));

            return CustomResponse(clienteViewModel);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ClienteViewModel>> Update(int id, ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.ClienteId)
            {
                NotifyError("O id informado não é o mesmo que foi informado na query");
                return CustomResponse(clienteViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _clienteService.Atualizar(_mapper.Map<Cliente>(clienteViewModel));

            return CustomResponse(clienteViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ClienteViewModel>> Delete(int id)
        {
            var clienteViewModel = _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterPorId(id));

            if (clienteViewModel == null)
            {
                return NotFound();
            }

            await _clienteService.Remover(id);

            return CustomResponse(clienteViewModel);
        }
    }
}
