using MediatR;

namespace FilmMVC.Application.Features.films.CreateCategory
{
    public sealed record CreateCategoryCommand(Guid Id, string Name):IRequest<Unit>;
    
}
