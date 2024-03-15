using Query.Domain.Abstractions.Options;

namespace Query.Infrastructure.DependencyInjection.Options;

public class MongoDbSettings : IMongoDbSettings
{
    public string DatabaseName { get; set; }
    public string ConnectionString { get; set; }
}
