using Sample.Domain.Common;

namespace Sample.Domain.Entities
{
    public class Category : AuditableEntity<Guid>
    {
        // public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Event>? Events { get; set; }
    }
}
