namespace DistributedSystem.Domain.Abstractions.Entities;

public abstract class Entity<T> : IEntity<T>
{
    public T Id { get; protected set; }
    public bool IsDeleted { get; protected set; }
}

//public abstract class DomainEntity<T> : IEntity<T>
//{
//    public T Id { get; protected set; }
//}