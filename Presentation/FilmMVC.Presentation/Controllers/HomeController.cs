using FilmMVC.Application.Features.details.ListDetails;
using FilmMVC.Application.Features.films.ListCategory;
using FilmMVC.Application.Features.films.ListFilms;
using FilmMVC.Application.Features.subscriptions.CreateSubscriptions;
using FilmMVC.Application.Interfaces.AutoMapper;
using FilmMVC.Domain.Entities;
using FilmMVC.Presentation.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmMVC.Presentation.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IMapper mapper;

        public HomeController(IMediator mediator, IMapper mapper) : base(mediator)
        {
            this.mapper = mapper;
        }


        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Index(Guid? categoryId)
        {  
                var requestCategories = await _mediator.Send(new ListCategoryCommand());
                var requestFilms = await _mediator.Send(new ListFilmsCommand());
                
            if (categoryId.HasValue && categoryId.Value != Guid.Empty)
            {
                requestFilms = requestFilms.Where(f => f.Category.CategoryId == categoryId.Value).ToList();
            }

            var viewModel = requestFilms.Select(e => new FilmsViewModel
            {
                FilmId = e.FilmId,
                FilmName = e.FilmName,
                UploadDate = e.UploadDate,
                ImageBase64 = e.Image != null ? Convert.ToBase64String(e.Image) : string.Empty,
                CategoryId = e.Category != null ? e.Category.CategoryId : Guid.Empty,
            }).ToList();

            var categoriesViewModel = requestCategories.Select(c => new CategoryViewModel
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName
            }).ToList();

            var model = new FilmsAndCategoryViewModel
            {
                Films = viewModel,
                Categories = categoriesViewModel,
                SelectedCategoryId = categoryId ?? Guid.Empty
            };

            return View(model);
        }

        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Details(Guid id,CancellationToken cancellationToken)
        {
            var filmDetails = await _mediator.Send(new ListDetailsCommand(id), cancellationToken);

            if (filmDetails == null)
            {
                return NotFound();
            }

            var viewModel = new DetailsViewModel
            {
                FilmId = filmDetails.FilmId,
                FilmName = filmDetails.FilmName,
                UploadDate = filmDetails.UploadDate,
                Image = filmDetails.Image != null ? Convert.ToBase64String(filmDetails.Image) : string.Empty,
                CategoryName = filmDetails.Category != null ? filmDetails.Category.CategoryName : string.Empty,
                Category = filmDetails.Category,
                Actors = filmDetails.Actors != null
                    ? filmDetails.Actors.Select(e => new ActorsViewModel
                    {
                        ActorId = e.ActorId,
                        ActorName = e.ActorName,
                    }).ToList()
                    : new List<ActorsViewModel>() 
            };

            return View(viewModel);
        }
    }
}
