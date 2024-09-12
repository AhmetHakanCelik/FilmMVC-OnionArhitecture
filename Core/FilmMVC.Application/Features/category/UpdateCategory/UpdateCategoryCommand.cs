using MediatR;

namespace FilmMVC.Application.Features.films.UpdateCategory
{
    public sealed record UpdateCategoryCommand(Guid Id):IRequest<Unit>;

}
