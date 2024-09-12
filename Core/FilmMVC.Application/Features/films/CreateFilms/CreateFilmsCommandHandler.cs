using FilmMVC.Application.Interfaces.Repositories;
using FilmMVC.Application.Interfaces.UnitOfWorks;
using FilmMVC.Domain.Entities;
using MediatR;

namespace FilmMVC.Application.Features.films.CreateFilms
{
    public class CreateFilmsCommandHandler : IRequestHandler<CreateFilmsCommand, Unit>
    {
        private readonly IFilmsRepository filmsRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateFilmsCommandHandler(IFilmsRepository filmsRepository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
        {
            this.filmsRepository = filmsRepository;
            this.unitOfWork = unitOfWork;
            this.categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(CreateFilmsCommand request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetByNameAsync(e => e.CategoryName == request.CategoryName);
            if (category == null)
            {
                category = new Category
                {
                    CategoryId = Guid.NewGuid(),
                    CategoryName = request.CategoryName
                };
                await categoryRepository.AddAsync(category, cancellationToken);
                await unitOfWork.SaveChangesAsync(cancellationToken);
            }

            Films film = new Films
            {
                FilmId = request.Id,
                FilmName = request.Name,
                UploadDate = DateTime.Now,
                Image = request.Image,
                Category = category,
            };

            await filmsRepository.AddAsync(film, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }

}
