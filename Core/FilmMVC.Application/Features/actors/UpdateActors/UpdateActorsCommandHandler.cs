using FilmMVC.Application.Interfaces.Repositories;
using FilmMVC.Application.Interfaces.UnitOfWorks;
using FilmMVC.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmMVC.Application.Features.actors.UpdateActors
{
    public class UpdateActorsCommandHandler : IRequestHandler<UpdateActorscommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IActorsRepository _actorsRepository;

        public UpdateActorsCommandHandler(IUnitOfWork unitOfWork, IActorsRepository actorsRepository)
        {
            _unitOfWork = unitOfWork;
            _actorsRepository = actorsRepository;
        }

        public async Task<Unit> Handle(UpdateActorscommand request, CancellationToken cancellationToken)
        {
            Actors actors = await _actorsRepository.GetByIdAsync(e => e.ActorId == request.Id);

            await _actorsRepository.UpdateAsync(actors);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
