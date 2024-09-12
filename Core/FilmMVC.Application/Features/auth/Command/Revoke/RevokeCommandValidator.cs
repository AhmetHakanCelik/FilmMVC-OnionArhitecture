using FluentValidation;

namespace FilmMVC.Application.Features.auth.Command.Revoke
{
    public class RevokeCommandValidator:AbstractValidator<RevokeCommandRequest>
    {
        public RevokeCommandValidator()
        {
            RuleFor(e => e.Email)
                .EmailAddress()
                .NotEmpty();
        }
    }
}
