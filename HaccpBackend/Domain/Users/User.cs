using HaccpBackend.Common;
using HaccpBackend.Domain.Organizations;
using Microsoft.AspNetCore.Identity;

namespace HaccpBackend.Domain.Users
{
    public class User : IdentityUser<int>, IAuditableEntity
    {
        public required Organization Organization { get; set; }

        public DateTime CreatedOnUtc { get ; private set ; }
        public DateTime? ModifiedOnUtc { get; private set; }

        public User() { }
    }
}
