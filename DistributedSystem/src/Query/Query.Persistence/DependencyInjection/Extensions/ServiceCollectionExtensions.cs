using Microsoft.Extensions.DependencyInjection;
using Query.Domain.Abstractions.Repositories;
using Query.Persistence.Repositories;

namespace Query.Persistence.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddServicesPersistence(this IServiceCollection services)
    {
        services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
    }
}