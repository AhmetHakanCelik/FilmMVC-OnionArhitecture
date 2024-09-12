namespace FilmMVC.Domain.Entities
{
    public class Films
    {
        public Guid FilmId { get; set; }
        public string FilmName { get; set; } = null!;
        public DateTime UploadDate { get; set; }
        public byte[]? Image { get; set; }
        public ICollection<Actors> Actors { get; set; }
        public Category Category { get; set; }

    }
}
