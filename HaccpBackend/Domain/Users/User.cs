using HaccpBackend.Common;
using HaccpBackend.Domain.Organizations;

namespace HaccpBackend.Domain.Users
{
    public class User : IAuditableEntity
    {
        public int Id { get; init; }
        public required string UserName { get; set; }
        public required string PasswordHash { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }

        public required Organization Organization { get; set; }

        public DateTime CreatedOnUtc { get ; private set ; }
        public DateTime? ModifiedOnUtc { get; private set; }

        public User() { }
    }
}
