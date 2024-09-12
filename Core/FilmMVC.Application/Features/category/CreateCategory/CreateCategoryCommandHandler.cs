using FilmMVC.Application.Interfaces.Repositories;
using FilmMVC.Application.Interfaces.UnitOfWorks;
using FilmMVC.Domain.Entities;
using MediatR;

namespace FilmMVC.Application.Features.films.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICategoryRepository categoryRepository;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
        {
            this.unitOfWork = unitOfWork;
            this.categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = new Category()
            {
                CategoryId = request.Id,
                CategoryName = request.Name
            };

            await categoryRepository.AddAsync(category,cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
