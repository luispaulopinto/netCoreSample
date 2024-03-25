using MediatR;

namespace Sample.Application.Features.Clients.Queries.GetClientWithSubClients
{
    public class GetClientsWithSubClientsQuery : IRequest<List<ClientListWithSubClientsVm>>
    {
        public string Type { get; set; }
    }
}
