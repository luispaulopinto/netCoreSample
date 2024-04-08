using Sample.Domain.Common;

namespace Sample.Domain.Entities
{
    public class Department
    {
        public int DepartmentId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Contact> Contacts { get; } = [];
    }
}
