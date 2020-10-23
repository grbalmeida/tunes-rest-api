using DevIO.Business.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tunes.Business.Interfaces;
using Tunes.Business.Interfaces.Repository;
using Tunes.Business.Interfaces.Services;
using Tunes.Business.Models;
using Tunes.Business.Models.Validations;

namespace Tunes.Business.Services
{
    public class FuncionarioService : BaseService, IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository, INotifier notificador) : base(notificador)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<bool> Adicionar(Funcionario funcionario)
        {
            if (!ExecutarValidacao(new FuncionarioValidation(), funcionario)) return false;

            await _funcionarioRepository.Adicionar(funcionario);

            return true;
        }

        public async Task<bool> Atualizar(Funcionario funcionario)
        {
            if (!ExecutarValidacao(new FuncionarioValidation(), funcionario)) return false;

            await _funcionarioRepository.Atualizar(funcionario);

            return true;
        }

        public async Task<bool> Remover(int id)
        {
            var funcionario = await _funcionarioRepository.ObterFuncionario(id);

            if (funcionario.Equipe.Any())
            {
                Notificar("O gerente possui funcionários!");
                return false;
            }

            if (funcionario.ClientesAtendidos.Any())
            {
                Notificar("O funcionário possui clientes vinculados!");
                return false;
            }

            await _funcionarioRepository.Remover(id);

            return true;
        }

        public void Dispose()
        {
            _funcionarioRepository?.Dispose();
        }
    }
}
