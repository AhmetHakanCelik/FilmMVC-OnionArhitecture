﻿using MediatR;

namespace FilmMVC.Application.Features.auth.Command.Login
{
    public class LoginCommandRequest:IRequest<LoginCommandResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
