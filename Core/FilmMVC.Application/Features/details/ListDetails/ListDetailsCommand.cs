using FilmMVC.Domain.Entities;
using MediatR;

namespace FilmMVC.Application.Features.details.ListDetails
{
    public sealed record ListDetailsCommand(Guid Id) : IRequest<Films>;
}
