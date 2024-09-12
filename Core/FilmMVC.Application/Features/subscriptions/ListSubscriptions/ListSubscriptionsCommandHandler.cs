using FilmMVC.Application.Interfaces.Repositories;
using FilmMVC.Application.Interfaces.UnitOfWorks;
using FilmMVC.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmMVC.Application.Features.subscriptions.ListSubscriptions
{
    public class ListSubscriptionsCommandHandler : IRequestHandler<ListSubscriptionsCommand, List<Subscriptions>>
    {
        private readonly ISubscriptionsRepository subscriptionsRepository;

        public ListSubscriptionsCommandHandler(ISubscriptionsRepository subscriptionsRepository)
        {
            this.subscriptionsRepository = subscriptionsRepository;
        }

        public async Task<List<Subscriptions>> Handle(ListSubscriptionsCommand request, CancellationToken cancellationToken)
        {
            return await subscriptionsRepository.GetAll().ToListAsync(cancellationToken);
        }
    }
}
