using HaccpBackend.Common;
using HaccpBackend.Domain.Users;

namespace HaccpBackend.Domain.Logs
{
    public class ActualLog : IAuditableEntity
    {
        public int Id { get; init; }
        public required Log BasedOnLog { get; init; }
        public required ActualLogStatus Status { get; set; }
        public required TimeOnly CanBeFilledFrom { get; init; }
        public User? CheckedBy { get; init; }
        public DateTime? CheckedOn { get; init; }

        public DateTime CreatedOnUtc { get; private set; }
        public DateTime? ModifiedOnUtc { get; private set; }

        public ActualLog() { }
    }
}


