using Sample.Domain.Interfaces;

namespace Sample.Domain.Common
{
    public abstract class AuditableEntity<T> : BaseEntity<T>, IAuditableEntity
    {
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
