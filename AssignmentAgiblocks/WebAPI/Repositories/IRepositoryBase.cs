using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AssignmentAgiblocks.WebAPI.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task<T> FindByExpression(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> FindAllAsync();
        Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();
    }
}
