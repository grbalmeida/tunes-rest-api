using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tunes.Api.Controllers;
using Tunes.Api.ViewModels;
using Tunes.Business.CollectionFilters;
using Tunes.Business.Interfaces;
using Tunes.Business.Interfaces.Repository;

namespace Tunes.Api.V2.Controllers
{
    [Authorize]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/funcionarios")]
    public class FuncionarioController : MainController
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IMapper _mapper;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository,
                                     IMapper mapper,
                                     INotifier notifier,
                                     IUser user) : base(notifier, user)
        {
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IList<FuncionarioViewModel>> GetAll([FromQuery] FuncionarioFiltro filtro)
        {
            return _mapper.Map<IList<FuncionarioViewModel>>(await _funcionarioRepository.Filtro(filtro));
        }
    }
}
