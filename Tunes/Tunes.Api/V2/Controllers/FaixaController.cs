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

        [HttpGet]
        [Route("excel")]
        public async Task<IActionResult> Excel([FromQuery] FaixaFiltro filtro)
        {
            var faixas = await _faixaRepository.Filtro(filtro);

            using (var wb = new XLWorkbook())
            {
                var ws = wb.AddWorksheet("Faixas");
                var linhaAtual = 1;
                ws.Cell(linhaAtual, (int)FaixaColumns.Nome).Value = "Nome";
                ws.Cell(linhaAtual, (int)FaixaColumns.Nome).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)FaixaColumns.Compositor).Value = "Compositor";
                ws.Cell(linhaAtual, (int)FaixaColumns.Compositor).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)FaixaColumns.Album).Value = "Álbum";
                ws.Cell(linhaAtual, (int)FaixaColumns.Album).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)FaixaColumns.TipoMidia).Value = "Tipo de Mídia";
                ws.Cell(linhaAtual, (int)FaixaColumns.TipoMidia).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)FaixaColumns.Genero).Value = "Gênero";
                ws.Cell(linhaAtual, (int)FaixaColumns.Genero).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)FaixaColumns.Milissegundos).Value = "Milissegundos";
                ws.Cell(linhaAtual, (int)FaixaColumns.Milissegundos).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)FaixaColumns.Bytes).Value = "Bytes";
                ws.Cell(linhaAtual, (int)FaixaColumns.Bytes).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)FaixaColumns.PrecoUnitario).Value = "Preço Unitário";
                ws.Cell(linhaAtual, (int)FaixaColumns.PrecoUnitario).Style.Font.Bold = true;

                foreach (var faixa in faixas)
                {
                    linhaAtual++;
                    ws.Cell(linhaAtual, (int)FaixaColumns.Nome).Value = faixa.Nome;
                    ws.Cell(linhaAtual, (int)FaixaColumns.Compositor).Value = faixa.Compositor;
                    ws.Cell(linhaAtual, (int)FaixaColumns.Album).Value = faixa?.Album?.Titulo;
                    ws.Cell(linhaAtual, (int)FaixaColumns.TipoMidia).Value = faixa?.TipoMidia?.Nome;
                    ws.Cell(linhaAtual, (int)FaixaColumns.Genero).Value = faixa?.Genero?.Nome;
                    ws.Cell(linhaAtual, (int)FaixaColumns.Milissegundos).Value = faixa.Milissegundos;
                    ws.Cell(linhaAtual, (int)FaixaColumns.Bytes).Value = faixa.Bytes;
                    ws.Cell(linhaAtual, (int)FaixaColumns.PrecoUnitario).Value = faixa.PrecoUnitario;
                }

                return await GerarArquivoExcel(wb, "faixas.xlsx");
            }
        }
    }
}
