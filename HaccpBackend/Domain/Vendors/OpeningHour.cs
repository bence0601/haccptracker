using HaccpBackend.Common;

namespace HaccpBackend.Domain.Vendors
{
public class OpeningHour : IAuditableEntity
{
    public int Id { get; init; }
    public required Vendor Vendor { get; init; }
    public required DayOfWeek DayOfWeek { get; init; }
    public required TimeOnly OpenAt { get; init; }
    public required TimeOnly CloseAt {  get; init; }
    public DateTime CreatedOnUtc { get; private set; }
    public DateTime? ModifiedOnUtc { get; private set; }

    public OpeningHour() { }
    }
}


