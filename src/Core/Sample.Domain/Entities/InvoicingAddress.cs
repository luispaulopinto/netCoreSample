using Sample.Domain.Common;

namespace Sample.Domain.Entities
{
    public class InvoicingAddress : AuditableEntity<int>
    {
        // public int InvoicingAddressId { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string PostlCode { get; set; }

        public string Street1 { get; set; }

        public string Street2 { get; set; }

        public int StreetNumber { get; set; }

        public string Complement { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public int InvoicingInfoId { get; set; }

        public InvoicingInfo InvoicingInfo { get; set; }
    }
}
