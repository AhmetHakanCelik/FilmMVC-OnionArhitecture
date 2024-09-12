using FilmMVC.Application.Interfaces.Repositories;
using FilmMVC.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FilmMVC.Application.Features.details.ListDetails
{
    public class ListDetailsCommandHandler : IRequestHandler<ListDetailsCommand, Films>
    {
        private readonly IFilmsRepository _filmsRepository;

        public ListDetailsCommandHandler(IFilmsRepository filmsRepository)
        {
            _filmsRepository = filmsRepository;
        }

        public async Task<Films> Handle(ListDetailsCommand request, CancellationToken cancellationToken)
        {
            var response = await _filmsRepository
                .GetByIdAndIncludeAsync(e => e.FilmId == request.Id,
                query => query
                .Include(e => e.Category)
                .Include(e => e.Actors),
                cancellationToken);

            return response;
        }
    }
}
