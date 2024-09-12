using FilmMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmMVC.Persistance.Configurations
{
    public class FilmsConfigurations : IEntityTypeConfiguration<Films>
    {
        public void Configure(EntityTypeBuilder<Films> builder)
        {
            builder.HasKey(x => x.FilmId);
        }
    }
}
