using Sample.Domain.Common;

namespace Sample.Domain.Entities
{
    public class InvoicingInfo : AuditableEntity<int>
    {
        // public int InvoicingInfoId { get; set; }

        // Razão Social / Company
        public string Name { get; set; }

        // Nome Fantasia
        public string TradeName { get; set; }

        // CNPJ
        public string RegisteredNumber { get; set; }

        // Email
        public string Email { get; set; }

        public int ClientIdParentLink { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public InvoicingAddress InvoicingAddress { get; set; }
    }
}
