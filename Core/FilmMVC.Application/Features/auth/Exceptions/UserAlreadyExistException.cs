using FilmMVC.Application.Bases;

namespace FilmMVC.Application.Features.auth.Exceptions
{
    public class UserAlreadyExistException : BaseExceptions
    {
        public UserAlreadyExistException() :base("Böyle Bir kullanıcı zaten var") { }
    }
}
