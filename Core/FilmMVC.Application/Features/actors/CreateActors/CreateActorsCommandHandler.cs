using FilmMVC.Application.Interfaces.Repositories;
using FilmMVC.Application.Interfaces.UnitOfWorks;
using FilmMVC.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmMVC.Application.Features.actors.CreateActors
{
    public class CreateActorsCommandHandler : IRequestHandler<CreateActorsCommand,Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IActorsRepository actorsRepository;

        public CreateActorsCommandHandler(IActorsRepository actorsRepository,IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.actorsRepository = actorsRepository;
        }

        public async Task<Unit> Handle(CreateActorsCommand request, CancellationToken cancellationToken)
        {
            Actors actors = new()
            {
                ActorId = request.Id,
                ActorName = request.Name,
            };

            await actorsRepository.AddAsync(actors, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
