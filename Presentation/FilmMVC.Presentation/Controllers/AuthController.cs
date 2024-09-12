using MediatR;
using Microsoft.AspNetCore.Mvc;
using FilmMVC.Application.Features.auth.Command.Register;
using FilmMVC.Presentation.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using FilmMVC.Application.Interfaces.Repositories;
using FilmMVC.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using FilmMVC.Application.Interfaces.Tokens;
using System.IdentityModel.Tokens.Jwt;
using FilmMVC.Application.Features.auth.Command.Login;

namespace FilmMVC.Presentation.Controllers
{
    public class AuthController:BaseController
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration configuration;
        public AuthController(IMediator mediator, IConfiguration configuration, IUserRepository userRepository, UserManager<User> userManager,ITokenService tokenService) : base(mediator)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _tokenService = tokenService;
            this.configuration = configuration;
        }

        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new LoginCommandRequest
                {
                    Email = model.Email,
                    Password = model.Password
                };

                var response = await _mediator.Send(command);

                if (response.Success)
                {
                    var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, model.Email),
                    new Claim(JwtRegisteredClaimNames.Email, model.Email)
                };

                    foreach (var role in await _userManager.GetRolesAsync(await _userManager.FindByEmailAsync(model.Email)))
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    _ = int.TryParse(configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(refreshTokenValidityInDays)
                    };

                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authProperties);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", response.Message);
                    return RedirectToAction("Register", "Auth");
                }
            }

            return View(model);

        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            var response= await _mediator.Send(request,cancellationToken);
            return RedirectToAction("Login");
        }

        
    }
}
