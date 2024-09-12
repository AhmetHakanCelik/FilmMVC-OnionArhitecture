using FilmMVC.Application.Bases;

namespace FilmMVC.Application.Features.auth.Exceptions
{
    public class RefreshTokenShouldnotBeInvalidException:BaseExceptions
    {
        public RefreshTokenShouldnotBeInvalidException() : base("Oturum süreniz dolmuştur. Lütfen tekrar deneyiniz.") { }
    }
}
