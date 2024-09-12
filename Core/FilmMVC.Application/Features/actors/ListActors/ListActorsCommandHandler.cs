using FilmMVC.Application.Interfaces.Repositories;
using FilmMVC.Application.Interfaces.UnitOfWorks;
using FilmMVC.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmMVC.Application.Features.actors.ListActors
{
    public class ListActorsCommandHandler : IRequestHandler<ListActorsCommand, List<Actors>>
    {
        private readonly IActorsRepository _actorsRepository;

        public ListActorsCommandHandler(IActorsRepository actorsRepository)
        {
            _actorsRepository = actorsRepository;
        }

        public async Task<List<Actors>> Handle(ListActorsCommand request, CancellationToken cancellationToken)
        {
            return await _actorsRepository.GetAll().ToListAsync(cancellationToken);
        }
    }
}
