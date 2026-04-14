using HaccpBackend.Common;

namespace HaccpBackend.Domain
{
    public class CheckItem : IAuditableEntity
    {
        public int Id { get; init; }

        public required string Name { get; set; }


        public DateTime CreatedOnUtc { get; private set; }
        public DateTime? ModifiedOnUtc { get; private set; }
    }
}
