using FilmMVC.Application.Features.subscriptions.CreateSubscriptions;
using FilmMVC.Application.Features.subscriptions.RemoveSubscriptions;
using FilmMVC.Presentation.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmMVC.Presentation.Controllers
{
    public class SubscriptionController:BaseController
    {
        public SubscriptionController(IMediator mediator) : base(mediator)
        {
        }

        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateSubscription(Guid Id, string Name, CancellationToken cancellationToken)
        {
            var subscription = await _mediator.Send(new CreateSubscriptionsCommand(Id), cancellationToken);

            var viewModel = new DetailsViewModel
            {

            };

            return View(viewModel); 
        }

        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteSubscription(Guid Id, string Name, CancellationToken cancellationToken)
        {
            var subscription = await _mediator.Send(new RemoveSubscriptionsCommand(Id), cancellationToken);
            return Ok();
        }

    }
}
