using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmMVC.Application.Features.actors.RemoveActors
{
    public sealed record RemoveActorsCommand(Guid Id):IRequest<Unit>;
}
