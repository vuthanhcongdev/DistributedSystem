namespace ApiGateway.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddReverseProxyApiGateway(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddReverseProxy()
            .LoadFromConfig(configuration.GetSection("ReverseProxy"));
    }
}
