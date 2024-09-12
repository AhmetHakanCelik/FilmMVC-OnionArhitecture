using FluentValidation;

namespace FilmMVC.Application.Features.auth.Command.Register
{
    public class RegisterCommandValidator:AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator()
        {
            RuleFor(e => e.Email)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(30)
                .EmailAddress()
                .WithName("E Mail");
            RuleFor(e => e.Password)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(50)
                .WithName("Şifre");
            RuleFor(e => e.ConfirmPassword)
                .NotEmpty()
                .Equal(e => e.Password)
                .WithName("Parolanızı Doğrulayın");
        }
    }
}
