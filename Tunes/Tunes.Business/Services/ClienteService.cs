using DevIO.Business.Services;
using System.Threading.Tasks;
using Tunes.Business.Interfaces;
using Tunes.Business.Interfaces.Repository;
using Tunes.Business.Interfaces.Services;
using Tunes.Business.Models;
using Tunes.Business.Models.Validations;

namespace Tunes.Business.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository,
                              INotifier notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Adicionar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return false;

            await _clienteRepository.Adicionar(cliente);

            return true;
        }

        public async Task<bool> Atualizar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return false;

            await _clienteRepository.Atualizar(cliente);

            return true;
        }

        public async Task<bool> Remover(int id)
        {
            await _clienteRepository.Remover(id);

            return true;
        }

        public void Dispose()
        {
            _clienteRepository?.Dispose();
        }
    }
}
