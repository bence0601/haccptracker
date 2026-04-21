using HaccpBackend.Common;

namespace HaccpBackend.Domain.CheckItems
{
    public class CheckItem : IAuditableEntity
    {
        public int Id { get; init; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public CheckItemType CheckItemType { get; set; }

        public DateTime CreatedOnUtc { get; private set; }
        public DateTime? ModifiedOnUtc { get; private set; }

        public CheckItem() { }
    }
}
