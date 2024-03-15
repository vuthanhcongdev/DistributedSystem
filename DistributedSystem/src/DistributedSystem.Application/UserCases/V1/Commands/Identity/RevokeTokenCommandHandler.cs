using DistributedSystem.Application.Abstractions;
using DistributedSystem.Contract.Abstractions.Message;
using DistributedSystem.Contract.Abstractions.Shared;
using DistributedSystem.Contract.Services.V1.Identity;
using System.Security.Claims;

namespace DistributedSystem.Application.UserCases.V1.Commands.Identity;

public class RevokeTokenCommandHandler : ICommandHandler<Command.Revoke>
{
    private readonly ICacheService _cacheService;
    private readonly IJwtTokenService _jwtTokenService;

    public RevokeTokenCommandHandler(ICacheService cacheService, IJwtTokenService jwtTokenService)
    {
        _cacheService = cacheService;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<Result> Handle(Command.Revoke request, CancellationToken cancellationToken)
    {
        var AccessToken = request.AccessToken;
        var principal = _jwtTokenService.GetPrincipalFromExpiredToken(AccessToken);
        var emailKey = principal.FindFirstValue(ClaimTypes.Email).ToString();

        var authenticated = await _cacheService.GetAsync<Response.Authenticated>(emailKey);
        if (authenticated is null)
            throw new Exception("Can not get value from Redis");

        await _cacheService.RemoveAsync(emailKey, cancellationToken);

        return Result.Success();
    }
}