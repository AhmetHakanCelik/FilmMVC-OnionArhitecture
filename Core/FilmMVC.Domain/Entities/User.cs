using Microsoft.AspNetCore.Identity;


namespace FilmMVC.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public int UserId { get; set; }
        public Guid SubscriptionId { get; set; }
        public string Password { get; set; } = null!;
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpireTime { get; set; }
        public ICollection<Subscriptions> Subscriptions { get; set; }
    }
}
