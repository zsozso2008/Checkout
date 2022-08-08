using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.DataAccess.Repositories
{
    public interface IRepositoryAsync<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
