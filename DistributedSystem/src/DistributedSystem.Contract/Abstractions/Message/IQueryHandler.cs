using DistributedSystem.Contract.Abstractions.Shared;
using MediatR;

namespace DistributedSystem.Contract.Abstractions.Message;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{ }
