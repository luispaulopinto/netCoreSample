using Sample.Domain.Common;

namespace Sample.Domain.Entities
{
    public class Contact : AuditableEntity
    {
        public int ContactId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string CellPhone { get; set; }

        public int ClientId { get; set; }

        public int DepartmentId { get; set; }
    }
}
