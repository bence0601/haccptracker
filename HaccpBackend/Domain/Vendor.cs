using HaccpBackend.Common;

namespace HaccpBackend.Domain
{
    public class Vendor : IAuditableEntity
    {
        public int Id { get; init; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public string? PhoneNumber { get; set; }

        public DateTime CreatedOnUtc { get; private set; }
        public DateTime? ModifiedOnUtc { get; private set; }

        public Vendor()
        {
        }
    }
}
