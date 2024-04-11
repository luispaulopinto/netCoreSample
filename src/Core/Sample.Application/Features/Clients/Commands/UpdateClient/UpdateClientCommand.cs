using MediatR;

namespace Sample.Application.Features.Clients.Commands.UpdateClient
{
    public class UpdateClientCommand : IRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Type { get; set; }

        public int? ParentId { get; set; }
    }
}
