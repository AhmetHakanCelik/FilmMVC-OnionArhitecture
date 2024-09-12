using FilmMVC.Application.Interfaces.Repositories;
using FilmMVC.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FilmMVC.Application.Features.films.ListCategory
{
    public class ListCategoryCommandHandler : IRequestHandler<ListCategoryCommand, List<Category>>
    {
        private readonly ICategoryRepository categoryRepository;

        public ListCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> Handle(ListCategoryCommand request, CancellationToken cancellationToken)
        {
            return await categoryRepository.GetAll().ToListAsync(cancellationToken);
        }
    }
}
