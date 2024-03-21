using MediatR;

namespace Sample.Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientCommand : IRequest<CreateClientCommandResponse>
    {
        public string Name { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;
    }
}
