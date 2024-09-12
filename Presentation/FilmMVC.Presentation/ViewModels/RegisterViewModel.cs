using System.ComponentModel.DataAnnotations;

namespace FilmMVC.Presentation.ViewModels
{
    public class RegisterViewModel
    {
        public string Name { get; set; } = null!;
        public string SurName { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor.")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
