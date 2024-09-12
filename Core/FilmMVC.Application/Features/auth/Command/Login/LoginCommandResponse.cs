
namespace FilmMVC.Application.Features.auth.Command.Login
{
    public class LoginCommandResponse
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string Message { get; set; }
    }
}
