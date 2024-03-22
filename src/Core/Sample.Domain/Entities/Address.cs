using Sample.Domain.Common;

namespace Sample.Domain.Entities
{
    public class Address : AuditableEntity
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string ZipCode { get; set; }

        public string Street { get; set; }

        public string StreetNumber { get; set; }

        public string Complement { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }
    }
}
