using HaccpBackend.Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace HaccpBackend.Domain.Entities
{
    public class User : IdentityUser<int>, IAuditableEntity
    {
        public required Organization Organization { get; set; }

        public DateTime CreatedOnUtc { get ; private set ; }
        public DateTime? ModifiedOnUtc { get; private set; }

        public User() { }
    }
}
