namespace Sample.Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientDto
    {
        public int ClientId { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public int? ParentClientId { get; set; }
    }
}
