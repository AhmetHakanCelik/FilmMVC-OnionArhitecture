using MediatR;

namespace FilmMVC.Application.Features.auth.Command.Revoke
{
    public class RevokeCommandRequest:IRequest<Unit>
    {
        public string Email { get; set; }
    }
}
