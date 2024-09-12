using FilmMVC.Application.Bases;
using FilmMVC.Application.Features.auth.Exceptions;
using FilmMVC.Domain.Entities;

namespace FilmMVC.Application.Features.auth.Rules
{
    public class AuthRules:BaseRules
    {
        public Task UserShouldNotBeExist(User user)
        {
            if(user is not null)
            {
                throw new UserAlreadyExistException();
            }
          
            return Task.CompletedTask;

        }

        public Task RefreshTokenShouldnotBeInvalid(DateTime expiredate)
        {
            if (expiredate <= DateTime.Now)
            {
                throw new RefreshTokenShouldnotBeInvalidException();
            } else
            {
                return Task.CompletedTask;
            }
        }

        public Task EmailShouldBeValid(User? user)
        {
            if (user is null)
            {
                throw new EmailShouldBeValidException();
            }
            else
            {
                return Task.CompletedTask;
            }
        }
    }
}
