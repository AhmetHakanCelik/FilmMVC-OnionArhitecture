using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FilmMVC.Presentation.Controllers
{
    public abstract class BaseController:Controller
    {
        public readonly IMediator _mediator;

        protected BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
