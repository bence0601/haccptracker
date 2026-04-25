using HaccpBackend.Domain.Common;

namespace HaccpBackend.Domain.Entities
{
    public class Organization : IAuditableEntity
    {
        public int Id { get; init; }
        public required string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime CreatedOnUtc { get; private set; }
        public DateTime? ModifiedOnUtc { get; private set; }

        public Organization()
        {
        }
    }
}
