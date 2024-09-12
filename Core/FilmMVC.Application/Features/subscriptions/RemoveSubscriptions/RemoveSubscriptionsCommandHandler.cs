using FilmMVC.Application.Interfaces.Repositories;
using FilmMVC.Application.Interfaces.UnitOfWorks;
using FilmMVC.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmMVC.Application.Features.subscriptions.RemoveSubscriptions
{
    public class RemoveSubscriptionsCommandHandler : IRequestHandler<RemoveSubscriptionsCommand, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ISubscriptionsRepository subscriptionsRepository;

        public RemoveSubscriptionsCommandHandler(IUnitOfWork unitOfWork, ISubscriptionsRepository subscriptionsRepository)
        {
            this.unitOfWork = unitOfWork;
            this.subscriptionsRepository = subscriptionsRepository;
        }

        public async Task<Unit> Handle(RemoveSubscriptionsCommand request, CancellationToken cancellationToken)
        {
            Subscriptions subscriptions = await subscriptionsRepository.GetByIdAsync(e => e.SubscriptionId == request.Id);

            await subscriptionsRepository.RemoveAsync(subscriptions);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }

}


