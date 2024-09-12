using FilmMVC.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmMVC.Application.Features.actors.ListActors
{
    public sealed record ListActorsCommand():IRequest<List<Actors>>;
    
}
