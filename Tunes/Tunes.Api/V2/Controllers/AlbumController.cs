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

        [HttpGet]
        [Route("excel")]
        public async Task<IActionResult> Excel([FromQuery] AlbumFiltro filtro)
        {
            var albuns = await _albumRepository.Filtro(filtro);

            using (var wb = new XLWorkbook())
            {
                var ws = wb.AddWorksheet("Álbuns");
                var linhaAtual = 1;
                ws.Cell(linhaAtual, (int)AlbumColumns.Titulo).Value = "Título";
                ws.Cell(linhaAtual, (int)AlbumColumns.Titulo).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)AlbumColumns.Artista).Value = "Artista";
                ws.Cell(linhaAtual, (int)AlbumColumns.Artista).Style.Font.Bold = true;

                foreach (var album in albuns)
                {
                    linhaAtual++;
                    ws.Cell(linhaAtual, (int)AlbumColumns.Titulo).Value = album.Titulo;
                    ws.Cell(linhaAtual, (int)AlbumColumns.Artista).Value = album.Artista.Nome;
                }

                return await GerarArquivoExcel(wb, "albuns.xlsx");
            }
        }
    }
}
