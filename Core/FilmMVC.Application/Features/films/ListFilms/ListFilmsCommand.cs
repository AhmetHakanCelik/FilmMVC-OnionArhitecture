using FilmMVC.Domain.Entities;
using MediatR;

namespace FilmMVC.Application.Features.films.ListFilms
{
    public sealed record ListFilmsCommand:IRequest<List<Films>>
    {
    }
}
