using FilmMVC.Application.Interfaces.Repositories;
using FilmMVC.Domain.Entities;
using FilmMVC.Persistance.Contexts;

namespace FilmMVC.Persistance.Repositories
{
    public class UserRepository :Repository<User>,IUserRepository
    {
        private readonly FilmMVCContext _context;
        public UserRepository(FilmMVCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<User> Users => _context.Users;
    }
}
