using FilmMVC.Application.Interfaces.Repositories;
using FilmMVC.Domain.Entities;
using FilmMVC.Persistance.Contexts;

namespace FilmMVC.Persistance.Repositories
{
    public class CategoryRepository : Repository<Category>,ICategoryRepository
    {
        public CategoryRepository(FilmMVCContext dbContext) : base(dbContext)
        {
        }
    }
}
