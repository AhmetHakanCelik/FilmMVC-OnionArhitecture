using System.Linq.Expressions;

namespace FilmMVC.Application.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        Task AddAsync(T entities, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entities);
        Task RemoveAsync(T entities);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
        Task<T> GetByIdAndIncludeAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IQueryable<T>> includeFunc = null, CancellationToken cancellationToken = default);
        Task<T> GetByNameAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
        IEnumerable<T> GetWhere(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();


    }
}
