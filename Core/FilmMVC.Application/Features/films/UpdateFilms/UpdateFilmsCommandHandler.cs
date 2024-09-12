
using FilmMVC.Application.Interfaces.Repositories;
using FilmMVC.Application.Interfaces.UnitOfWorks;
using FilmMVC.Domain.Entities;
using MediatR;

namespace FilmMVC.Application.Features.films.UpdateFilms
{
    public class UpdateFilmsCommandHandler : IRequestHandler<UpdateFilmsCommand, Unit>
    {
        private readonly IFilmsRepository filmsRepository;
        private readonly IUnitOfWork unitOfWork;

        public UpdateFilmsCommandHandler(IFilmsRepository filmsRepository, IUnitOfWork unitOfWork)
        {
            this.filmsRepository = filmsRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateFilmsCommand request, CancellationToken cancellationToken)
        {
            Films films = await filmsRepository.GetByIdAsync(e => e.FilmId == request.Id);

            await filmsRepository.UpdateAsync(films);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
