using FilmMVC.Application.Interfaces.Repositories;
using FilmMVC.Application.Interfaces.UnitOfWorks;
using FilmMVC.Domain.Entities;
using MediatR;

namespace FilmMVC.Application.Features.films.RemoveFilms
{
    public class RemoveFilmsCommandHandler : IRequestHandler<RemoveFilmsCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFilmsRepository _filmsRepository;

        public RemoveFilmsCommandHandler(IUnitOfWork unitOfWork, IFilmsRepository filmsRepository)
        {
            _unitOfWork = unitOfWork;
            _filmsRepository = filmsRepository;
        }

        public async Task<Unit> Handle(RemoveFilmsCommand request, CancellationToken cancellationToken)
        {
            Films films = await _filmsRepository.GetByIdAsync(e => e.FilmId ==request.Id);
            await _filmsRepository.RemoveAsync(films);
            await _unitOfWork.SaveChangesAsync(cancellationToken);   

            return Unit.Value;
        }
    }

}
