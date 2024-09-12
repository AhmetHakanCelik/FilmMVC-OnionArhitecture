using System.ComponentModel.DataAnnotations;

namespace FilmMVC.Presentation.ViewModels
{
    public class LoginViewModel
    {
       
            [Required]
            [EmailAddress]
            public string Email { get; set; } = null!;

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; } = null!;


    }
}
