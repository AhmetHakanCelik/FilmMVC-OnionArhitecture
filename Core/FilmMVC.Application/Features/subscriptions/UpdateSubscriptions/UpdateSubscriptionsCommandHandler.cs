using FilmMVC.Application.Interfaces.Repositories;
using FilmMVC.Application.Interfaces.UnitOfWorks;
using FilmMVC.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmMVC.Application.Features.subscriptions.UpdateSubscriptions
{
    public class UpdateSubscriptionsCommandHandler : IRequestHandler<UpdateSubscriptionsCommand, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ISubscriptionsRepository subscriptionsRepository;

        public UpdateSubscriptionsCommandHandler(IUnitOfWork unitOfWork, ISubscriptionsRepository subscriptionsRepository)
        {
            this.unitOfWork = unitOfWork;
            this.subscriptionsRepository = subscriptionsRepository;
        }

        public async Task<Unit> Handle(UpdateSubscriptionsCommand request, CancellationToken cancellationToken)
        {
            Subscriptions subscriptions = await subscriptionsRepository.GetByIdAsync(e => e.SubscriptionId == request.Id);

            await subscriptionsRepository.UpdateAsync(subscriptions);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
