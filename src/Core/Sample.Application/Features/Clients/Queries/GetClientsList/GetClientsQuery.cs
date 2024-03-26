using MediatR;

namespace Sample.Application.Features.Clients.Queries.GetClients
{
    public class GetClientsQuery : IRequest<List<ClientsListVm>>
    {
        public string? Type { get; set; }
    }
}
