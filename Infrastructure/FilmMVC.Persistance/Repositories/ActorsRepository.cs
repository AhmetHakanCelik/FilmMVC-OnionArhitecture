using FilmMVC.Application.Interfaces.Repositories;
using FilmMVC.Domain.Entities;
using FilmMVC.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FilmMVC.Persistance.Repositories
{
    internal class ActorsRepository : Repository<Actors>, IActorsRepository
    {
        public ActorsRepository(FilmMVCContext dbContext) : base(dbContext)
        {
        }
    }
}
