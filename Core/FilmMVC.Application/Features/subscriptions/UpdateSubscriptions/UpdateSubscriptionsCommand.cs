using MediatR;

namespace FilmMVC.Application.Features.subscriptions.UpdateSubscriptions
{
    public sealed record UpdateSubscriptionsCommand(Guid Id):IRequest<Unit>;

}
