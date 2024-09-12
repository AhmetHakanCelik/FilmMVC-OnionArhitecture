namespace FilmMVC.Presentation.ViewModels
{
    public class FilmsAndCategoryViewModel
    {
        public Guid SelectedCategoryId { get; set; }
        public List<FilmsViewModel> Films { get; set; } = new List<FilmsViewModel>();
        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
