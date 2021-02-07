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

        [HttpGet]
        [Route("excel")]
        public async Task<IActionResult> Excel([FromQuery] FuncionarioFiltro filtro)
        {
            var funcionarios = await _funcionarioRepository.Filtro(filtro);

            using (var wb = new XLWorkbook())
            {
                var ws = wb.AddWorksheet("Funcionários");
                var linhaAtual = 1;
                ws.Cell(linhaAtual, (int)FuncionarioColumns.NomeCompleto).Value = "Nome Completo";
                ws.Cell(linhaAtual, (int)FuncionarioColumns.NomeCompleto).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)FuncionarioColumns.Titulo).Value = "Título";
                ws.Cell(linhaAtual, (int)FuncionarioColumns.Titulo).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)FuncionarioColumns.DataNascimento).Value = "Data de Nascimento";
                ws.Cell(linhaAtual, (int)FuncionarioColumns.DataNascimento).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)FuncionarioColumns.DataAdmissao).Value = "Data de Admissão";
                ws.Cell(linhaAtual, (int)FuncionarioColumns.DataAdmissao).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)FuncionarioColumns.Gerente).Value = "Gerente";
                ws.Cell(linhaAtual, (int)FuncionarioColumns.Gerente).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)FuncionarioColumns.Endereco).Value = "Endereço";
                ws.Cell(linhaAtual, (int)FuncionarioColumns.Endereco).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)FuncionarioColumns.Cidade).Value = "Cidade";
                ws.Cell(linhaAtual, (int)FuncionarioColumns.Cidade).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)FuncionarioColumns.Estado).Value = "Estado";
                ws.Cell(linhaAtual, (int)FuncionarioColumns.Estado).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)FuncionarioColumns.Pais).Value = "País";
                ws.Cell(linhaAtual, (int)FuncionarioColumns.Pais).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)FuncionarioColumns.CEP).Value = "CEP";
                ws.Cell(linhaAtual, (int)FuncionarioColumns.CEP).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)FuncionarioColumns.Fone).Value = "Fone";
                ws.Cell(linhaAtual, (int)FuncionarioColumns.Fone).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)FuncionarioColumns.Fax).Value = "Fax";
                ws.Cell(linhaAtual, (int)FuncionarioColumns.Fax).Style.Font.Bold = true;
                ws.Cell(linhaAtual, (int)FuncionarioColumns.Email).Value = "Email";
                ws.Cell(linhaAtual, (int)FuncionarioColumns.Email).Style.Font.Bold = true;

                foreach (var funcionario in funcionarios)
                {
                    linhaAtual++;
                    ws.Cell(linhaAtual, (int)FuncionarioColumns.NomeCompleto).Value = $"{funcionario.PrimeiroNome} {funcionario.Sobrenome}";
                    ws.Cell(linhaAtual, (int)FuncionarioColumns.Titulo).Value = funcionario.Titulo;
                    ws.Cell(linhaAtual, (int)FuncionarioColumns.DataNascimento).Value = funcionario.DataNascimento.ToString("dd/MM/yyyy");
                    ws.Cell(linhaAtual, (int)FuncionarioColumns.DataAdmissao).Value = funcionario.DataAdmissao.ToString("dd/MM/yyyy");
                    ws.Cell(linhaAtual, (int)FuncionarioColumns.Gerente).Value = $"{funcionario.Gerente?.PrimeiroNome} {funcionario.Gerente?.Sobrenome}".Trim();
                    ws.Cell(linhaAtual, (int)FuncionarioColumns.Endereco).Value = funcionario.Endereco;
                    ws.Cell(linhaAtual, (int)FuncionarioColumns.Cidade).Value = funcionario.Cidade;
                    ws.Cell(linhaAtual, (int)FuncionarioColumns.Estado).Value = funcionario.Estado;
                    ws.Cell(linhaAtual, (int)FuncionarioColumns.Pais).Value = funcionario.Pais;
                    ws.Cell(linhaAtual, (int)FuncionarioColumns.CEP).Value = funcionario.CEP;
                    ws.Cell(linhaAtual, (int)FuncionarioColumns.Fone).Value = funcionario.Fone;
                    ws.Cell(linhaAtual, (int)FuncionarioColumns.Fax).Value = funcionario.Fax;
                    ws.Cell(linhaAtual, (int)FuncionarioColumns.Email).Value = funcionario.Email;
                }

                return await GerarArquivoExcel(wb, "funcionarios.xlsx");
            }
        }
    }
}
