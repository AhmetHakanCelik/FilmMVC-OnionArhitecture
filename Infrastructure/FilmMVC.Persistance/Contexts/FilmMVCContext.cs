using FilmMVC.Application.Interfaces.UnitOfWorks;
using FilmMVC.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace FilmMVC.Persistance.Contexts
{
    public class FilmMVCContext : IdentityDbContext<User,Role,Guid>,IUnitOfWork
    {
        public FilmMVCContext(DbContextOptions<FilmMVCContext> options) : base(options)
        {

        }

        public DbSet<Actors> Actors { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Films> Films { get; set; }
        public DbSet<Subscriptions> Subscriptions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<IdentityRoleClaim<Guid>>();
            modelBuilder.Ignore<IdentityUserLogin<Guid>>();

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
        
    }
}
