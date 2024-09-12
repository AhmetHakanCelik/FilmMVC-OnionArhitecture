using FilmMVC.Application.Interfaces.Repositories;
using FilmMVC.Application.Interfaces.UnitOfWorks;
using FilmMVC.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmMVC.Application.Features.actors.RemoveActors
{
    public class RemoveActorsCommandHandler : IRequestHandler<RemoveActorsCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IActorsRepository _actorsRepository;

        public RemoveActorsCommandHandler(IUnitOfWork unitOfWork, IActorsRepository actorsRepository)
        {
            _unitOfWork = unitOfWork;
            _actorsRepository = actorsRepository;
        }

        public async Task<Unit> Handle(RemoveActorsCommand request, CancellationToken cancellationToken)
        {
            Actors actors = await _actorsRepository.GetByIdAsync(e => e.ActorId == request.Id,cancellationToken);

            await _actorsRepository.RemoveAsync(actors);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }

}
