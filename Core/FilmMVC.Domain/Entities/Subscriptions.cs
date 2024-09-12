namespace FilmMVC.Domain.Entities
{
    public class Subscriptions
    {
        public Guid SubscriptionId { get; set; }
        public string SubscriptionName { get; set; } = null!;
        public Category category { get; set; }
        public User User { get; set; }
    }
}
