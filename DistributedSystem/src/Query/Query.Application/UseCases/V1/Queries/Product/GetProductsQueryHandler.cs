using DistributedSystem.Contract.Abstractions.Message;
using DistributedSystem.Contract.Abstractions.Shared;
using DistributedSystem.Contract.Services.V1.Product;
using MongoDB.Driver;
using Query.Domain.Abstractions.Repositories;
using Query.Domain.Entities;

namespace Query.Application.UseCases.V1.Queries.Product;

public sealed class GetProductsQueryHandler : IQueryHandler<DistributedSystem.Contract.Services.V1.Product.Query.GetProductsQuery, List<Response.ProductResponse>>
{
    private readonly IMongoRepository<ProductProjection> _productRepository;


    public GetProductsQueryHandler(IMongoRepository<ProductProjection> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<List<Response.ProductResponse>>> Handle(DistributedSystem.Contract.Services.V1.Product.Query.GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.AsQueryable().ToListAsync();
        var result = new List<Response.ProductResponse>();

        foreach (var item in products)
        {
            result.Add(new Response.ProductResponse(item.DocumentId, item.Name, item.Price, item.Description));
        }
        return Result.Success(result);
    }
}