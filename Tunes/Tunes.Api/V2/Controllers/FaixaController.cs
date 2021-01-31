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
    [Route("api/v{version:apiVersion}/faixas")]
    public class FaixaController : MainController
    {
        private readonly IFaixaRepository _faixaRepository;
        private readonly IMapper _mapper;

        public FaixaController(IFaixaRepository faixaRepository,
                               IMapper mapper,
                               INotifier notifier,
                               IUser user) : base(notifier, user)
        {
            _faixaRepository = faixaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IList<FaixaViewModel>> GetAll([FromQuery] FaixaFiltro filtro)
        {
            return _mapper.Map<IList<FaixaViewModel>>(await _faixaRepository.Filtro(filtro));
        }
    }
}
