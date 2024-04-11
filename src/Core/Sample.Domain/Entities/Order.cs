using Sample.Domain.Common;

namespace Sample.Domain.Entities
{
    public class Order : AuditableEntity<Guid>
    {
        // public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
        public bool OrderPaid { get; set; }
    }
}
