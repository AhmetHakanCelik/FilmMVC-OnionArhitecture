using FilmMVC.Domain.Entities;
using MediatR;

namespace FilmMVC.Application.Features.subscriptions.ListSubscriptions
{
    public sealed record ListSubscriptionsCommand():IRequest<List<Subscriptions>>;
}
