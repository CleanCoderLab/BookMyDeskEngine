
using System.Linq.Expressions;

namespace BookMyDesk.SharedKernel.Contracts
{
    public interface ICRUDRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        Task<T> InsertAsync(T entity);
        Task InsertRangeAsync(IEnumerable<T> entities);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
        Task DeleteByIdAsync(object id);

        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

        Task<int> SaveChangesAsync();
    }
}
