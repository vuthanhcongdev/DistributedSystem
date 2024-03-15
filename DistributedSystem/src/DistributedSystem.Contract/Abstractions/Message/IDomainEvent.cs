using MassTransit;

namespace DistributedSystem.Contract.Abstractions.Message;

[ExcludeFromTopology]
public interface IDomainEvent
{
    public Guid IdEvent { get; init; }
}