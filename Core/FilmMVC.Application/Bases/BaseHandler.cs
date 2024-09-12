using FilmMVC.Application.Interfaces.AutoMapper;
using FilmMVC.Application.Interfaces.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FilmMVC.Application.Bases
{
    public class BaseHandler
    {
        public IMapper mapper;
        public readonly IHttpContextAccessor httpContextAccessor;
        public readonly IUnitOfWork unitOfWork;
        public readonly string? userID;
        public BaseHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.unitOfWork = unitOfWork;
            userID = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
