using FilmMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmMVC.Persistance.Configurations
{
    public class SubscriptionsConfigurations : IEntityTypeConfiguration<Subscriptions>
    {
        public void Configure(EntityTypeBuilder<Subscriptions> builder)
        {
            builder.HasKey(x => x.SubscriptionId);
            builder.HasOne(x => x.User)
                   .WithMany(x => x.Subscriptions)
                   .HasForeignKey(x => x.SubscriptionId);

            builder.HasOne(x => x.category)
                   .WithMany(x => x.Subscriptions)
                   .HasForeignKey(x => x.SubscriptionId);
        }
    }
}
