
namespace FilmMVC.Domain.Entities
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public Guid SubscriptionId { get; set; }
        public string CategoryName { get; set; } = null!;
        public ICollection<Films> Films { get; set; }
        public ICollection<Subscriptions> Subscriptions { get; set; }
    }
}
