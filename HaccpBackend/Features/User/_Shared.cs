using HaccpBackend.Domain.Entities;

namespace HaccpBackend.Features.User
{
    public static class _Shared
    {
        public sealed record UserResponse(
            int UserID,
            string UserName,
            string Email,
            int OrganizationID
        );
    }
}
