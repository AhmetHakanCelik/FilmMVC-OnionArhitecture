using FilmMVC.Domain.Entities;
using MediatR;

namespace FilmMVC.Application.Features.subscriptions.CreateSubscriptions
{
    public sealed record CreateSubscriptionsCommand(Guid Id) :IRequest<Subscriptions>;

}
