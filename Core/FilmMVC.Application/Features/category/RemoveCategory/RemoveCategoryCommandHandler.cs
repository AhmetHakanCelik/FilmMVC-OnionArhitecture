using FilmMVC.Application.Interfaces.Repositories;
using FilmMVC.Application.Interfaces.UnitOfWorks;
using FilmMVC.Domain.Entities;
using MediatR;

namespace FilmMVC.Application.Features.films.RemoveCategory
{
    public class RemoveCategoryCommandHandler:IRequestHandler<RemoveCategoryCommand,Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICategoryRepository categoryRepository;

        public RemoveCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
        {
            this.unitOfWork = unitOfWork;
            this.categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = await categoryRepository.GetByIdAsync(e => e.CategoryId == request.Id);
            await categoryRepository.RemoveAsync(category);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
