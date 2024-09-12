using MediatR;

namespace FilmMVC.Application.Features.films.UpdateFilms
{
    public sealed record UpdateFilmsCommand(Guid Id):IRequest<Unit>
    {
    }
}
