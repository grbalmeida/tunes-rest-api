using AutoMapper;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tunes.Api.Controllers;
using Tunes.Api.Excel;
using Tunes.Api.ViewModels;
using Tunes.Business.CollectionFilters;
using Tunes.Business.Interfaces;
using Tunes.Business.Interfaces.Repository;

namespace Tunes.Api.V2.Controllers
{
    [Authorize]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/playlists")]
    public class PlaylistController : MainController
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IMapper _mapper;

        public PlaylistController(IPlaylistRepository playlistRepository,
                                  IMapper mapper,
                                  INotifier notifier,
                                  IUser user) : base(notifier, user)
        {
            _playlistRepository = playlistRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IList<PlaylistViewModel>> GetAll([FromQuery] PlaylistFiltro filtro)
        {
            return _mapper.Map<IList<PlaylistViewModel>>(await _playlistRepository.Filtro(filtro));
        }

        [HttpGet]
        [Route("excel")]
        public async Task<IActionResult> Excel([FromQuery] PlaylistFiltro filtro)
        {
            var playlists = await _playlistRepository.Filtro(filtro);

            using (var wb = new XLWorkbook())
            {
                var ws = wb.AddWorksheet("Playlists");
                var linhaAtual = 1;
                ws.Cell(linhaAtual, (int)PlaylistColumns.Nome).Value = "Nome";
                ws.Cell(linhaAtual, (int)PlaylistColumns.Nome).Style.Font.Bold = true;

                foreach (var playlist in playlists)
                {
                    linhaAtual++;
                    ws.Cell(linhaAtual, (int)PlaylistColumns.Nome).Value = playlist.Nome;
                }

                return await GerarArquivoExcel(wb, "playlists.xlsx");
            }
        }
    }
}
