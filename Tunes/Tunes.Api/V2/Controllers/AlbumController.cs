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
    [Route("api/v{version:apiVersion}/albuns")]
    public class AlbumController : MainController
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;

        public AlbumController(IAlbumRepository albumRepository,
                               IMapper mapper,
                               INotifier notifier,
                               IUser user) : base(notifier, user)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IList<AlbumViewModel>> GetAll([FromQuery] AlbumFiltro filtro)
        {
            return _mapper.Map<IList<AlbumViewModel>>(await _albumRepository.Filtro(filtro));
        }
    }
}
