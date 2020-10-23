using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tunes.Business.Models;

namespace Tunes.Business.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Adicionar(TEntity entity);
        Task<TEntity> ObterPorId(int id);
        Task<List<TEntity>> ObterTodos();
        Task<IEnumerable<TEntity>> Busca(Expression<Func<TEntity, bool>> predicate);
        Task Atualizar(TEntity entity);
        Task Remover(int id);
        Task<int> SalvarAlteracoes();
    }
}
