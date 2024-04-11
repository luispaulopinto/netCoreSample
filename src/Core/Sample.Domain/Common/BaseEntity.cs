using Sample.Domain.Interfaces;

namespace Sample.Domain.Common
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; }

        // public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}
