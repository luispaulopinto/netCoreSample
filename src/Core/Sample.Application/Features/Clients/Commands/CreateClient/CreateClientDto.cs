namespace Sample.Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public string TradeName { get; set; } = string.Empty;

        // CNPJ
        public string RegisteredNumber { get; set; } = string.Empty;

        //Inscrição estadual
        public string StateRegistration { get; set; } = string.Empty;

        public bool IsStateRegistrationFree { get; set; } = false;

        public string LogoURL { get; set; } = string.Empty;

        public string Language { get; set; } = string.Empty;

        public string CurrencyType { get; set; } = string.Empty;

        public string TimeZone { get; set; } = string.Empty;

        public string Origin { get; set; } = string.Empty;

        public int? ParentClientId { get; set; }
    }
}
