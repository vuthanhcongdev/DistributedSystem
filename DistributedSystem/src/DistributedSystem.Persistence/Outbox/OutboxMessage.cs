namespace DistributedSystem.Persistence.Outbox;

public class OutboxMessage
{
    public Guid Id { get; set; }

    public string Type { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public DateTimeOffset OccurredOnUtc { get; set; }       

    public DateTimeOffset? ProcessedOnUtc { get; set; }

    public string? Error { get; set; }
}