using FilmMVC.Application.Interfaces.Repositories;
using FilmMVC.Application.Interfaces.UnitOfWorks;
using FilmMVC.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FilmMVC.Application.Features.subscriptions.CreateSubscriptions
{
    public class CreateSubscriptionsCommandHandler : IRequestHandler<CreateSubscriptionsCommand, Subscriptions>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ISubscriptionsRepository subscriptionsRepository;
        private readonly ICategoryRepository categoryRepository;

        public CreateSubscriptionsCommandHandler(ISubscriptionsRepository subscriptionsRepository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
        {
            this.unitOfWork = unitOfWork;
            this.subscriptionsRepository = subscriptionsRepository;
            this.categoryRepository = categoryRepository;
        }

        public async Task<Subscriptions> Handle(CreateSubscriptionsCommand request, CancellationToken cancellationToken)
        {
            var isSubscriberExist = await categoryRepository.GetByIdAndIncludeAsync(e => e.CategoryId == request.Id,
                query => query
                .Include(e => e.SubscriptionId));

            if (isSubscriberExist is not null) 
            { 
               throw new ArgumentNullException("Abonelik zaten var");
            }

            Subscriptions subscriber = new()
            {
                SubscriptionId = request.Id,
            };

            return subscriber;

        }
    }

}
