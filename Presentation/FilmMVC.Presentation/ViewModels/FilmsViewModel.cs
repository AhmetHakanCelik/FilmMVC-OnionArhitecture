
namespace FilmMVC.Presentation.ViewModels
{
    public class FilmsViewModel
    {
        public Guid FilmId { get; set; }
        public string FilmName { get; set; } = null!;
        public DateTime UploadDate { get; set; }
        public IFormFile Image { get; set; } = null!;
        public string ImageBase64 { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public Guid CategoryId { get; set; }
    }
}
