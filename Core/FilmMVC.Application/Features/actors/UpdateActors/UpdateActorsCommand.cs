using FilmMVC.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmMVC.Application.Features.actors.UpdateActors
{
    public sealed record UpdateActorscommand(Guid Id):IRequest<Unit>;
}
