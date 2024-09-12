using MediatR;

namespace FilmMVC.Application.Features.films.CreateFilms
{
    public sealed record CreateFilmsCommand(Guid Id,string Name,byte[] Image,string CategoryName):IRequest<Unit>
    {
         
    }
}
