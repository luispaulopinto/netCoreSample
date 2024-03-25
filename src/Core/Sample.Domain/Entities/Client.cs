using Sample.Domain.Common;

namespace Sample.Domain.Entities
{
    public class Client : AuditableEntity
    {
        public int ClientId { get; set; }

        // Razão Social / Company
        public string Name { get; set; }

        // Nome Fantasia
        public string TradeName { get; set; }

        // CNPJ
        public string RegisteredNumber { get; set; }

        //Inscrição estadual
        public string StateRegistration { get; set; }

        public bool IsStateRegistrationFree { get; set; }

        public string LogoURL { get; set; }

        public string Type { get; set; }

        public string Language { get; set; }

        public string CurrencyType { get; set; }

        public string TimeZone { get; set; }

        public string Origin { get; set; }

        public int? ParentClientId { get; set; }

        public Client ParentClient { get; set; }

        public Address Address { get; set; }

        public ICollection<Client>? ChildrenClient { get; set; }
    }
}
