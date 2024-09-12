namespace FilmMVC.Domain.Entities
{
    public class Actors
    {
        public Guid ActorId { get; set; }
        public string ActorName { get; set; } = null!;
        public ICollection<Films> Films { get; set; }
    }
}
