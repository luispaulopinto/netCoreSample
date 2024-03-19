using Sample.Domain.Entities;

namespace Sample.Application.Contracts.Persistence
{
    public interface IClientRepository : IAsyncRepository<Event>
    {
        Task<List<Client>> GetClientsListWithSubClients();

        Task<Client> GetClient(int ClientId, bool includeChildren);
    }
}
