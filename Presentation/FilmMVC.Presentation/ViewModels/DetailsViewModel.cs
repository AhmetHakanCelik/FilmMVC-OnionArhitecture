using FilmMVC.Domain.Entities;

namespace FilmMVC.Presentation.ViewModels
{
    public class DetailsViewModel
    {
        public Guid FilmId { get; set; }
        public string FilmName { get; set; } = null!;
        public string? CategoryName { get; set; }
        public DateTime UploadDate { get; set; }
        public string Image { get; set; } = string.Empty;
        public List<ActorsViewModel> Actors { get; set; } = new List<ActorsViewModel>();
        public Category? Category { get; set; }
    }
}
