
using Sample.Domain.Common;

namespace Sample.Domain.Entities
{
    public class Client : AuditableEntity
    {
        public int ClientId { get; set; }
        public string Name { get; set; }  
        public Client? ParentClient { get; set; } 
        
        public ICollection<Client>? ChildrenClient { get; set; }
    }
}
