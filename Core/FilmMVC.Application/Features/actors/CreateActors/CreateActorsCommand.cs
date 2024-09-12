using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmMVC.Application.Features.actors.CreateActors
{
    public sealed record CreateActorsCommand(Guid Id,string Name):IRequest<Unit>;
}
