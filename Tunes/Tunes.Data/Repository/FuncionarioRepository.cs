using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tunes.Business.CollectionFilters;
using Tunes.Business.Interfaces.Repository;
using Tunes.Business.Models;
using Tunes.Data.Context;

namespace Tunes.Data.Repository
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(TunesContext context) : base(context) { }

        public async Task<Funcionario> ObterFuncionario(int id)
        {
            return await DbSet.Include(f => f.Equipe)
                .Include(f => f.ClientesAtendidos)
                .FirstOrDefaultAsync(f => f.FuncionarioId == id);
        }

        public async override Task<Funcionario> ObterPorId(int id)
        {
            return await DbSet.Include(f => f.Gerente)
                .Include(f => f.Equipe)
                .Include(f => f.ClientesAtendidos)
                .FirstOrDefaultAsync(f => f.FuncionarioId == id);
        }

        public async Task<IList<Funcionario>> Filtro(FuncionarioFiltro filtro)
        {
            var funcionarioQuery = DbSet.AsNoTracking();

            if (filtro != null)
            {
                if (!string.IsNullOrEmpty(filtro.PrimeiroNome))
                    funcionarioQuery = funcionarioQuery.Where(f => f.PrimeiroNome.Contains(filtro.PrimeiroNome));

                if (!string.IsNullOrEmpty(filtro.Sobrenome))
                    funcionarioQuery = funcionarioQuery.Where(f => f.Sobrenome.Contains(filtro.Sobrenome));

                if (!string.IsNullOrEmpty(filtro.Titulo))
                    funcionarioQuery = funcionarioQuery.Where(f => f.Titulo.Contains(filtro.Titulo));

                if (filtro.DataNascimento.HasValue)
                {
                    var dataNascimento = filtro.DataNascimento.Value.Date;
                    funcionarioQuery = funcionarioQuery.Where(f => f.DataNascimento.Date == dataNascimento);
                }

                if (filtro.DataAdmissao.HasValue)
                {
                    var dataAdmissao = filtro.DataAdmissao.Value.Date;
                    funcionarioQuery = funcionarioQuery.Where(f => f.DataAdmissao.Date == dataAdmissao);
                }

                if (!string.IsNullOrEmpty(filtro.Endereco))
                    funcionarioQuery = funcionarioQuery.Where(f => f.Endereco.Contains(filtro.Endereco));

                if (!string.IsNullOrEmpty(filtro.Cidade))
                    funcionarioQuery = funcionarioQuery.Where(f => f.Cidade.Contains(filtro.Cidade));

                if (!string.IsNullOrEmpty(filtro.Estado))
                    funcionarioQuery = funcionarioQuery.Where(f => f.Estado.Contains(filtro.Estado));

                if (!string.IsNullOrEmpty(filtro.Pais))
                    funcionarioQuery = funcionarioQuery.Where(f => f.Pais.Contains(filtro.Pais));

                if (!string.IsNullOrEmpty(filtro.CEP))
                    funcionarioQuery = funcionarioQuery.Where(f => f.CEP.Contains(filtro.CEP));

                if (!string.IsNullOrEmpty(filtro.Fone))
                    funcionarioQuery = funcionarioQuery.Where(f => f.Fone.Contains(filtro.Fone));

                if (!string.IsNullOrEmpty(filtro.Fax))
                    funcionarioQuery = funcionarioQuery.Where(f => f.Fax.Contains(filtro.Fax));

                if (!string.IsNullOrEmpty(filtro.Email))
                    funcionarioQuery = funcionarioQuery.Where(f => f.Email.Contains(filtro.Email));

                if (filtro.GerenteId > 0)
                {
                    funcionarioQuery = funcionarioQuery.Where(f => f.Gerente.FuncionarioId == filtro.GerenteId);
                }
            }

            return await funcionarioQuery
                .Include(f => f.Gerente)
                .ToListAsync();
        }
    }
}
