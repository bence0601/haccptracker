using HaccpBackend.Domain.Common;

namespace HaccpBackend.Domain.Entities
{
    public class VendorUserAccess : IAuditableEntity
    {
        public int Id { get; init; }
        public required Vendor Vendor { get; init; }
        public required User User { get; init; }
        public required Role Role { get; set; }
        public bool IsPrimaryLocation { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }

        public VendorUserAccess() { }
    }
}
