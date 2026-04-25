using HaccpBackend.Domain.Common;

namespace HaccpBackend.Domain.Entities
{
    public abstract class ActualCheckItem : IAuditableEntity
    {
        public int Id { get; init; }
        public required CheckItem BasedOnCheckItem { get; init; }
        public CheckItemType CheckItemType { get; set; }

        public DateTime CreatedOnUtc { get; private set; }
        public DateTime? ModifiedOnUtc { get; private set; }
    }

    public class BooleanCheckItem : ActualCheckItem
    {
        public bool Value { get; set; }
    }

    public class NumericCheckItem : ActualCheckItem
    {
        public decimal Value { get; set; }
    }

    public class TextCheckItem : ActualCheckItem
    {
        public string Value { get; set; } = string.Empty;
    }
}

