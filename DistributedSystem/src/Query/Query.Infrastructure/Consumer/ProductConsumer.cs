using DistributedSystem.Contract.Services.V1.Product;
using MediatR;
using Query.Domain.Abstractions.Repositories;
using Query.Domain.Entities;
using Query.Infrastructure.Abstractions;

namespace Query.Infrastructure.Consumer;

public static class ProductConsumer
{
    public class ProductCreatedConsumer : Consumer<DomainEvent.ProductCreated>
    {
        public ProductCreatedConsumer(ISender sender, IMongoRepository<EventProjection> eventRepository)
            : base(sender, eventRepository)
        {
        }
    }

    public class ProductDeletedConsumer : Consumer<DomainEvent.ProductDeleted>
    {
        public ProductDeletedConsumer(ISender sender, IMongoRepository<EventProjection> eventRepository)
            : base(sender, eventRepository)
        {
        }
    }

    public class ProductUpdatedConsumer : Consumer<DomainEvent.ProductUpdated>
    {
        public ProductUpdatedConsumer(ISender sender, IMongoRepository<EventProjection> eventRepository)
            : base(sender, eventRepository)
        {
        }
    }
}
