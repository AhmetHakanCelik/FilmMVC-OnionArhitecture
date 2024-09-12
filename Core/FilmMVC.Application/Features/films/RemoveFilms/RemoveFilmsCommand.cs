using MediatR;

namespace FilmMVC.Application.Features.films.RemoveFilms
{
    public sealed record RemoveFilmsCommand(Guid Id):IRequest<Unit>
    {
    }
}
