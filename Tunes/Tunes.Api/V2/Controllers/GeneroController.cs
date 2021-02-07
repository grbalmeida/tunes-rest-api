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
    [Route("api/v{version:apiVersion}/generos")]
    public class GeneroController : MainController
    {
        private readonly IGeneroRepository _generoRepository;
        private readonly IMapper _mapper;

        public GeneroController(IGeneroRepository generoRepository,
                                 IMapper mapper,
                                 INotifier notifier,
                                 IUser user) : base(notifier, user)
        {
            _generoRepository = generoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IList<GeneroViewModel>> GetAll([FromQuery] GeneroFiltro filtro)
        {
            return _mapper.Map<IList<GeneroViewModel>>(await _generoRepository.Filtro(filtro));
        }

        [HttpGet]
        [Route("excel")]
        public async Task<IActionResult> Excel([FromQuery] GeneroFiltro filtro)
        {
            var generos = await _generoRepository.Filtro(filtro);

            using (var wb = new XLWorkbook())
            {
                var ws = wb.AddWorksheet("Gêneros");
                var linhaAtual = 1;
                ws.Cell(linhaAtual, (int)GeneroColumns.Nome).Value = "Nome";
                ws.Cell(linhaAtual, (int)GeneroColumns.Nome).Style.Font.Bold = true;

                foreach (var genero in generos)
                {
                    linhaAtual++;
                    ws.Cell(linhaAtual, (int)GeneroColumns.Nome).Value = genero.Nome;
                }

                return await GerarArquivoExcel(wb, "generos.xlsx");
            }
        }
    }
}
