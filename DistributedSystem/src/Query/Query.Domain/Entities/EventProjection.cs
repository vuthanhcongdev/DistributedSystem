using Query.Domain.Abstractions;
using Query.Domain.Attributes;
using Query.Domain.Constants;

namespace Query.Domain.Entities;

[BsonCollection(CollectionNames.Event)]
public class EventProjection : Document
{
    public Guid EventId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
}