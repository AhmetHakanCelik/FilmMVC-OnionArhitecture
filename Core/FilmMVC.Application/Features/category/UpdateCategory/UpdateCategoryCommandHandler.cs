using FilmMVC.Application.Interfaces.Repositories;
using FilmMVC.Application.Interfaces.UnitOfWorks;
using FilmMVC.Domain.Entities;
using MediatR;

namespace FilmMVC.Application.Features.films.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICategoryRepository categoryRepository;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
        {
            this.unitOfWork = unitOfWork;
            this.categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = await categoryRepository.GetByIdAsync(e => e.CategoryId == request.Id);

            await categoryRepository.UpdateAsync(category);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
