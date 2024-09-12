using FilmMVC.Application.Interfaces.Repositories;
using FilmMVC.Domain.Entities;
using FilmMVC.Persistance.Contexts;

namespace FilmMVC.Persistance.Repositories
{
    internal class FilmsRepository : Repository<Films>, IFilmsRepository
    {
        public FilmsRepository(FilmMVCContext dbContext) : base(dbContext)
        {
        }
    }
}
