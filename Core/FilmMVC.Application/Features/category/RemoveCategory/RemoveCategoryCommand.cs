using MediatR;

namespace FilmMVC.Application.Features.films.RemoveCategory
{
    public sealed record RemoveCategoryCommand(Guid Id):IRequest<Unit>;
    
}
