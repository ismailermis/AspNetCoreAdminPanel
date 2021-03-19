using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> Query(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        IEnumerable<T> Filter(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "",
            int? page = null,
            int? pageSize = null);
        List<T> GetAll();
        T GetById(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllAsync(ISpecification<T> spec);
        T Find(Expression<Func<T, bool>> match);
        List<T> FindAll(Expression<Func<T, bool>> match);
        Task<List<T>> FindAllAsync(Expression<Func<T, bool>> match);
        T Add(T entity);
        Task<T> AddAsync(T entity);
        bool BulkInsert(List<T> entities);
        T Update(T entity);
        Task<T> UpdateAsync(T entity);
        int Delete(T entity);
        Task<int> CountAsync(ISpecification<T> spec);
    }
}
