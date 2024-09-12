using FilmMVC.Application.Interfaces.Repositories;
using FilmMVC.Domain.Entities;
using FilmMVC.Persistance.Contexts;

namespace FilmMVC.Persistance.Repositories
{
    internal class SubscriptionsRepository : Repository<Subscriptions>, ISubscriptionsRepository
    {
        public SubscriptionsRepository(FilmMVCContext dbContext) : base(dbContext)
        {
        }
    }
}
