using FilmMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmMVC.Application.Interfaces.Repositories
{
    public interface IUserRepository:IRepository<User>
    {
        IQueryable<User> Users { get; }
    }
}
