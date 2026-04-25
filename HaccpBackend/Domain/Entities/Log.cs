using HaccpBackend.Domain.Common;

namespace HaccpBackend.Domain.Entities
{
public class Log : IAuditableEntity
{

    public int Id { get; init; }
    public required string Name { get; set; }
    public required TimeSpan TimeToFill { get; set; }
    public string? Description { get; set; }

    public DateTime CreatedOnUtc { get; private set; }
    public DateTime? ModifiedOnUtc { get; private set; }

    public Log()
    {
    }
}
}


