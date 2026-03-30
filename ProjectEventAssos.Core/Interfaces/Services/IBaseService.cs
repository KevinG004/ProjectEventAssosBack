using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ProjectEventAssos.Core.Interfaces.Services
{
    public interface IBaseService<TEntity, TKey>
    where TEntity : class
    where TKey : struct
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(TKey id);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> ExistsAsync(TKey id);
        Task<int> CountAsync();


        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TKey id, TEntity entity);
        Task DeleteAsync(TKey id);
    }
}
