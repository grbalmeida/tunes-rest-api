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
    [Route("api/v{version:apiVersion}/clientes")]
    public class ClienteController : MainController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteController(IClienteRepository clienteRepository,
                                 IMapper mapper,
                                 INotifier notifier,
                                 IUser user) : base(notifier, user)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IList<ClienteViewModel>> GetAll([FromQuery] ClienteFiltro filtro)
        {
            return _mapper.Map<IList<ClienteViewModel>>(await _clienteRepository.Filtro(filtro));
        }

        [HttpGet]
        [Route("excel")]
        public async Task<IActionResult> Excel([FromQuery] ClienteFiltro filtro)
        {
            var clientes = await _clienteRepository.Filtro(filtro);

            using (var wb = new XLWorkbook())
            {
                var ws = wb.AddWorksheet("Clientes");
                var linhaAtual = 1;
                ws.Cell(linhaAtual, (int)ClienteColumns.NomeCompleto).Value = "Nome Completo";
                ws.Cell(linhaAtual, (int)ClienteColumns.NomeCompleto).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)ClienteColumns.Empresa).Value = "Empresa";
                ws.Cell(linhaAtual, (int)ClienteColumns.Empresa).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)ClienteColumns.Suporte).Value = "Suporte";
                ws.Cell(linhaAtual, (int)ClienteColumns.Suporte).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)ClienteColumns.Endereco).Value = "Endereço";
                ws.Cell(linhaAtual, (int)ClienteColumns.Endereco).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)ClienteColumns.Cidade).Value = "Cidade";
                ws.Cell(linhaAtual, (int)ClienteColumns.Cidade).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)ClienteColumns.Estado).Value = "Estado";
                ws.Cell(linhaAtual, (int)ClienteColumns.Estado).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)ClienteColumns.Pais).Value = "País";
                ws.Cell(linhaAtual, (int)ClienteColumns.Pais).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)ClienteColumns.CEP).Value = "CEP";
                ws.Cell(linhaAtual, (int)ClienteColumns.CEP).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)ClienteColumns.Fone).Value = "Fone";
                ws.Cell(linhaAtual, (int)ClienteColumns.Fone).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)ClienteColumns.Fax).Value = "Fax";
                ws.Cell(linhaAtual, (int)ClienteColumns.Fax).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)ClienteColumns.Email).Value = "Email";
                ws.Cell(linhaAtual, (int)ClienteColumns.Email).Style.Font.Bold = true;

                foreach (var cliente in clientes)
                {
                    linhaAtual++;
                    ws.Cell(linhaAtual, (int)ClienteColumns.NomeCompleto).Value = $"{cliente.PrimeiroNome} {cliente.Sobrenome}";
                    ws.Cell(linhaAtual, (int)ClienteColumns.Empresa).Value = cliente.Empresa;
                    ws.Cell(linhaAtual, (int)ClienteColumns.Suporte).Value = $"{cliente.Suporte?.PrimeiroNome} {cliente.Suporte?.Sobrenome}".Trim();
                    ws.Cell(linhaAtual, (int)ClienteColumns.Endereco).Value = cliente.Endereco;
                    ws.Cell(linhaAtual, (int)ClienteColumns.Cidade).Value = cliente.Cidade;
                    ws.Cell(linhaAtual, (int)ClienteColumns.Estado).Value = cliente.Estado;
                    ws.Cell(linhaAtual, (int)ClienteColumns.Pais).Value = cliente.Pais;
                    ws.Cell(linhaAtual, (int)ClienteColumns.CEP).Value = cliente.CEP;
                    ws.Cell(linhaAtual, (int)ClienteColumns.Fone).Value = cliente.Fone;
                    ws.Cell(linhaAtual, (int)ClienteColumns.Fax).Value = cliente.Fax;
                    ws.Cell(linhaAtual, (int)ClienteColumns.Email).Value = cliente.Email;
                }

                return await GerarArquivoExcel(wb, "funcionarios.xlsx");
            }
        }
    }
}
