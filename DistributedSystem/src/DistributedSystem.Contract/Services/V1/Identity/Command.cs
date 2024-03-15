using DistributedSystem.Contract.Abstractions.Message;

namespace DistributedSystem.Contract.Services.V1.Identity;

public static class Command
{
    public record Revoke(string AccessToken) : ICommand;
}