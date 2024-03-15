using DistributedSystem.Contract.Abstractions.Message;
using DistributedSystem.Contract.Abstractions.Shared;
using DistributedSystem.Contract.Services.V1.Product;
using Query.Domain.Abstractions.Repositories;
using Query.Domain.Entities;
using Query.Domain.Exceptions;

namespace Query.Application.UseCases.V1.Queries.Product;

public sealed class GetProductByIdQueryHandler : IQueryHandler<DistributedSystem.Contract.Services.V1.Product.Query.GetProductByIdQuery, Response.ProductResponse>
{
    private readonly IMongoRepository<ProductProjection> _productRepository;

    public GetProductByIdQueryHandler(IMongoRepository<ProductProjection> productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<Result<Response.ProductResponse>> Handle(DistributedSystem.Contract.Services.V1.Product.Query.GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.FindOneAsync(p => p.DocumentId == request.Id)
            ?? throw new ProductException.ProductNotFoundException(request.Id);

        var result = new Response.ProductResponse(product.DocumentId, product.Name, product.Price, product.Description);

        return Result.Success(result);
    }
}
