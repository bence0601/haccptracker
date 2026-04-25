namespace HaccpBackend.Domain.Common
{
    internal interface IAuditableEntity
    {
        DateTime CreatedOnUtc { get;}
        DateTime? ModifiedOnUtc { get;}
    }
}
