using MediatR;

namespace FilmMVC.Application.Features.auth.Command.Register
{
    public class RegisterCommandRequest:IRequest<RegisterCommandResponse>
    {
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;

    }
}
