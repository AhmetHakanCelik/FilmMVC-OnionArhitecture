using FilmMVC.Application.Interfaces.Repositories;
using FilmMVC.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FilmMVC.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class,new()
    {
        private readonly FilmMVCContext _dbContext;

        public Repository(FilmMVCContext dbContext)
        {
            _dbContext = dbContext;
        }

        private DbSet<T> _context { get =>  _dbContext.Set<T>(); }
        public async Task AddAsync(T entities, CancellationToken cancellationToken = default)
        {
             await _dbContext.AddAsync(entities,cancellationToken);
        }

        public IQueryable<T> GetAll()
        {
            return _context.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAndIncludeAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IQueryable<T>> includeFunc = null, CancellationToken cancellationToken = default)
        {
            IQueryable<T> response = _context.AsNoTracking().Where(expression);

            if (includeFunc != null) 
            { 
                response  = includeFunc(response);
            }

            return await response.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            var response =await _context.Where(expression).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
            return response;
        }

        public async Task<T> GetByNameAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
                var response = await _context.Where(expression).AsNoTracking().FirstOrDefaultAsync(expression, cancellationToken);
                return response; 
        }

        public IEnumerable<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            return _context.Where(expression).AsNoTracking().ToList();
        }

        public async Task RemoveAsync(T entities)
        {
            await Task.Run(() => _context.Remove(entities));
        }

        public async Task UpdateAsync(T entities)
        {
            await Task.Run(() => _context.Update(entities));
        }
    }
}
