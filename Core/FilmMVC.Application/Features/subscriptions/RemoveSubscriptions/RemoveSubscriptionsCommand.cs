using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmMVC.Application.Features.subscriptions.RemoveSubscriptions
{
    public sealed record RemoveSubscriptionsCommand(Guid Id):IRequest<Unit>;
}
