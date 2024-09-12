using FilmMVC.Application.Interfaces.Tokens;
using FilmMVC.Infrastructure.Tokens;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace FilmMVC.Infrastructure
{
    public static class Registiration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
             services.Configure<TokenSettings>(configuration.GetSection("JWT"));
             services.AddTransient<ITokenService, TokenService>();

             services.AddAuthentication(options =>
             {
                   options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                   options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; 
                   options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
             })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = "/Auth/login";
                })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
                {
                    opt.SaveToken = true;
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
                        ValidIssuer = configuration["JWT:Issuer"],
                        ValidAudience = configuration["JWT:Audience"],
                        ClockSkew = TimeSpan.Zero

                    };
                });
        }
    }
}
