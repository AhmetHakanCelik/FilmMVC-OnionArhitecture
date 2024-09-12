using FilmMVC.Domain.Entities;
using MediatR;

namespace FilmMVC.Application.Features.films.ListCategory
{
    public sealed record ListCategoryCommand():IRequest<List<Category>>
    {
    }
}
