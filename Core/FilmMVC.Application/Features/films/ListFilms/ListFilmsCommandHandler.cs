using FilmMVC.Application.Interfaces.Repositories;
using FilmMVC.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FilmMVC.Application.Features.films.ListFilms
{
    public class ListFilmsCommandHandler : IRequestHandler<ListFilmsCommand, List<Films>>
    {
        private readonly IFilmsRepository filmsRepository;

        public ListFilmsCommandHandler(IFilmsRepository filmsRepository)
        {
            this.filmsRepository = filmsRepository;
        }

        public async Task<List<Films>> Handle(ListFilmsCommand request, CancellationToken cancellationToken)
        {
            return await filmsRepository
                .GetAll()
                .Include(e => e.Category)
                .ToListAsync(cancellationToken);
        }
    }
}
