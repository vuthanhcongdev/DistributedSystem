using DistributedSystem.Contract.Abstractions.Message;
using DistributedSystem.Contract.Abstractions.Shared;
using DistributedSystem.Contract.Services.V1.Product;
using Query.Domain.Abstractions.Repositories;
using Query.Domain.Entities;

namespace Query.Application.UseCases.V1.Commands;

internal class ProjectProductDetailsWhenProductChangedEventHandler
    : ICommandHandler<DomainEvent.ProductCreated>,
    ICommandHandler<DomainEvent.ProductDeleted>,
    ICommandHandler<DomainEvent.ProductUpdated>
{
    // Repository working with MongoDB
    private readonly IMongoRepository<ProductProjection> _productRepository;

    public ProjectProductDetailsWhenProductChangedEventHandler(IMongoRepository<ProductProjection> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result> Handle(DomainEvent.ProductCreated request, CancellationToken cancellationToken)
    {
        var product = new ProductProjection()
        {
            DocumentId = request.Id,
            Name = request.Name,
            Price = request.Price,
            Description = request.Description,
        };
        // Create new a product
        await _productRepository.InsertOneAsync(product);

        return Result.Success();
    }

    public async Task<Result> Handle(DomainEvent.ProductDeleted request, CancellationToken cancellationToken)
    {
        // Find and delete product
        var product = await _productRepository.FindOneAsync(p => p.DocumentId == request.Id)
            ?? throw new ArgumentNullException();

        await _productRepository.DeleteOneAsync(p => p.DocumentId == request.Id);

        return Result.Success();
    }

    public async Task<Result> Handle(DomainEvent.ProductUpdated request, CancellationToken cancellationToken)
    {
        // Find and update product
        var product = await _productRepository.FindOneAsync(p => p.DocumentId == request.Id)
           ?? throw new ArgumentNullException();

        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;
        product.ModifiedOnUtc = DateTime.UtcNow;

        await _productRepository.ReplaceOneAsync(product);

        return Result.Success();
    }

}