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
    [Route("api/v{version:apiVersion}/tipos-de-midia")]
    public class TipoMidiaController : MainController
    {
        private readonly ITipoMidiaRepository _tipoMidiaRepository;
        private readonly IMapper _mapper;

        public TipoMidiaController(ITipoMidiaRepository tipoMidiaRepository,
                                   IMapper mapper,
                                   INotifier notifier,
                                   IUser user) : base(notifier, user)
        {
            _tipoMidiaRepository = tipoMidiaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IList<TipoMidiaViewModel>> GetAll([FromQuery] TipoMidiaFiltro filtro)
        {
            return _mapper.Map<IList<TipoMidiaViewModel>>(await _tipoMidiaRepository.Filtro(filtro));
        }
    }
}
