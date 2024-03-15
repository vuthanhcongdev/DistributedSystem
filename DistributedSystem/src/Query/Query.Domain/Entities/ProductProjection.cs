using Query.Domain.Abstractions;
using Query.Domain.Attributes;
using Query.Domain.Constants;

namespace Query.Domain.Entities;

[BsonCollection(CollectionNames.Product)]
public class ProductProjection : Document
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
}