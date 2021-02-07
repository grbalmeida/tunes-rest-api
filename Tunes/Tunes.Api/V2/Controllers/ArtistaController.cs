using AutoMapper;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
    [Route("api/v{version:apiVersion}/artistas")]
    public class ArtistaController : MainController
    {
        private readonly IArtistaRepository _artistaRepository;
        private readonly IMapper _mapper;

        public ArtistaController(IArtistaRepository artistaRepository,
                                 IMapper mapper,
                                 INotifier notifier,
                                 IUser user) : base(notifier, user)
        {
            _artistaRepository = artistaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IList<ArtistaViewModel>> GetAll([FromQuery] ArtistaFiltro filtro)
        {
            return _mapper.Map<IList<ArtistaViewModel>>(await _artistaRepository.Filtro(filtro));
        }

        [HttpGet]
        [Route("excel")]
        public async Task<IActionResult> Excel([FromQuery] ArtistaFiltro filtro)
        {
            var artistas = await _artistaRepository.Filtro(filtro);

            using (var wb = new XLWorkbook())
            {
                var ws = wb.AddWorksheet("Artistas");
                var linhaAtual = 1;
                ws.Cell(linhaAtual, (int)ArtistaColumns.Nome).Value = "Nome";
                ws.Cell(linhaAtual, (int)ArtistaColumns.Nome).Style.Font.Bold = true;

                foreach (var artista in artistas)
                {
                    linhaAtual++;
                    ws.Cell(linhaAtual, (int)ArtistaColumns.Nome).Value = artista.Nome;
                }

                return await GerarArquivoExcel(wb, "artistas.xlsx");
            }
        }
    }
}
