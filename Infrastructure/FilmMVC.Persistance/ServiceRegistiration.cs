using FilmMVC.Application.Interfaces.Repositories;
using FilmMVC.Application.Interfaces.Tokens;
using FilmMVC.Application.Interfaces.UnitOfWorks;
using FilmMVC.Domain.Entities;
using FilmMVC.Infrastructure.Tokens;
using FilmMVC.Persistance.Contexts;
using FilmMVC.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FilmMVC.Persistance
{
    public static class ServiceRegistiration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FilmMVCContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultString"));
            });

            services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 4;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;
                opt.SignIn.RequireConfirmedPhoneNumber = false;
                opt.SignIn.RequireConfirmedEmail = false;
            })
            .AddRoles<Role>()
            .AddEntityFrameworkStores<FilmMVCContext>();

            services.AddScoped<IUnitOfWork>(cfg => cfg.GetRequiredService<FilmMVCContext>());
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
            services.AddScoped(typeof(ISubscriptionsRepository), typeof(SubscriptionsRepository));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IFilmsRepository), typeof(FilmsRepository));
            services.AddScoped(typeof(IActorsRepository), typeof(ActorsRepository));
            
        }
    }


}
