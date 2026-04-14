namespace HaccpBackend.Common
{
    internal interface IAuditableEntity
    {
        DateTime CreatedOnUtc { get; set; }
        DateTime? ModifiedOnUtc { get; set; }
    }
}
