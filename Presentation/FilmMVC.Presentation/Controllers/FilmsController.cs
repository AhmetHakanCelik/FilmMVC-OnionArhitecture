using FilmMVC.Application.Features.films.CreateFilms;
using FilmMVC.Application.Interfaces.AutoMapper;
using FilmMVC.Presentation.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmMVC.Presentation.Controllers
{

    public class FilmsController : BaseController
    {
        private readonly IMapper mapper;
        public FilmsController(IMediator mediator, IMapper mapper) : base(mediator)
        {
            this.mapper = mapper;
        }

        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
         public IActionResult CreateFilms()
         {
             return View();
         }

        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<IActionResult> CreateFilms(FilmsViewModel model,CancellationToken cancellationToken)
        {
            byte[] imageBytes = null;

            if (model.Image != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.Image.CopyToAsync(memoryStream);
                    imageBytes = memoryStream.ToArray();
                }

            }

            var request = new CreateFilmsCommand(model.FilmId, model.FilmName,imageBytes,model.CategoryName);
            await _mediator.Send(request, cancellationToken);
            var filmsViewModel = mapper.Map<FilmsViewModel>(request);
            return RedirectToAction("Index", "Home");
        }

    }
}
