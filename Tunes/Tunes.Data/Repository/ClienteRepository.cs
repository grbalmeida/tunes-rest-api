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
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(TunesContext context) : base(context) { }

        public async override Task<Cliente> ObterPorId(int id)
        {
            return await DbSet
                .Include(c => c.Suporte)
                .FirstOrDefaultAsync(c => c.ClienteId == id);
        }

        public async Task<IList<Cliente>> Filtro(ClienteFiltro filtro)
        {
            var clienteQuery = DbSet.AsNoTracking();

            if (filtro != null)
            {
                if (!string.IsNullOrEmpty(filtro.PrimeiroNome))
                    clienteQuery = clienteQuery.Where(c => c.PrimeiroNome.Contains(filtro.PrimeiroNome));

                if (!string.IsNullOrEmpty(filtro.Sobrenome))
                    clienteQuery = clienteQuery.Where(c => c.Sobrenome.Contains(filtro.Sobrenome));

                if (!string.IsNullOrEmpty(filtro.Empresa))
                    clienteQuery = clienteQuery.Where(c => c.Empresa.Contains(filtro.Empresa));

                if (!string.IsNullOrEmpty(filtro.Endereco))
                    clienteQuery = clienteQuery.Where(c => c.Endereco.Contains(filtro.Endereco));

                if (!string.IsNullOrEmpty(filtro.Cidade))
                    clienteQuery = clienteQuery.Where(c => c.Cidade.Contains(filtro.Cidade));

                if (!string.IsNullOrEmpty(filtro.Estado))
                    clienteQuery = clienteQuery.Where(c => c.Estado.Contains(filtro.Estado));

                if (!string.IsNullOrEmpty(filtro.Pais))
                    clienteQuery = clienteQuery.Where(c => c.Pais.Contains(filtro.Pais));

                if (!string.IsNullOrEmpty(filtro.CEP))
                    clienteQuery = clienteQuery.Where(c => c.CEP.Contains(filtro.CEP));

                if (!string.IsNullOrEmpty(filtro.Fone))
                    clienteQuery = clienteQuery.Where(c => c.Fone.Contains(filtro.Fone));

                if (!string.IsNullOrEmpty(filtro.Fax))
                    clienteQuery = clienteQuery.Where(c => c.Fax.Contains(filtro.Fax));

                if (!string.IsNullOrEmpty(filtro.Email))
                    clienteQuery = clienteQuery.Where(c => c.Email.Contains(filtro.Email));
            }

            return await clienteQuery.ToListAsync();
        }
    }
}
