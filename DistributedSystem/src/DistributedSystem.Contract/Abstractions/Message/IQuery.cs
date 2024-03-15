using DistributedSystem.Contract.Abstractions.Shared;
using MediatR;

namespace DistributedSystem.Contract.Abstractions.Message;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{ }
