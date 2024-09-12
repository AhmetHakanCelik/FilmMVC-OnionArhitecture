using FilmMVC.Application.Bases;
using FilmMVC.Application.Features.auth.Rules;
using FilmMVC.Application.Interfaces.AutoMapper;
using FilmMVC.Application.Interfaces.UnitOfWorks;
using FilmMVC.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace FilmMVC.Application.Features.auth.Command.Register
{
    public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest,RegisterCommandResponse>
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly AuthRules authRules;
        public RegisterCommandHandler(UserManager<User> userManager, RoleManager<Role> roleManager,
        IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, AuthRules authRules, IMapper mapper) : base(mapper, httpContextAccessor, unitOfWork)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.authRules = authRules;
        }

        public async Task<RegisterCommandResponse> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new RegisterCommandResponse();
            await authRules.UserShouldNotBeExist(await userManager.FindByEmailAsync(request.Email));

            User user = mapper.Map<User,RegisterCommandRequest>(request);
            user.UserName = request.Email;
            user.Email = request.Email;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = await userManager.CreateAsync(user,request.Password);
            if (result.Succeeded) 
            { 
                if(!await roleManager.RoleExistsAsync("User"))
                {
                    await roleManager.CreateAsync(new Role
                    {
                        Id = Guid.NewGuid(),
                        Name = "User",
                        NormalizedName= "USER",
                        ConcurrencyStamp = Guid.NewGuid().ToString(),   
                    });

                    await userManager.AddToRoleAsync(user, "User");
                }

            response.IsSuccessful = true;
            }

            return response;

        }
    }
}
