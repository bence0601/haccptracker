using HaccpBackend.Common;

namespace HaccpBackend.Domain
{
    public class User : IAuditableEntity
    {
        public int Id { get; init; }
        public required string UserName { get; set; }
        public required string PasswordHash { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }

        public Organization? Organization { get; set; }

        public DateTime CreatedOnUtc { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? ModifiedOnUtc { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
