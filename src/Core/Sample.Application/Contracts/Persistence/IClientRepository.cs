using Sample.Domain.Entities;

namespace Sample.Application.Contracts.Persistence
{
    public interface IClientRepository : IAsyncRepository<Client>
    {
        Task<Client> GetByIdAsync(int id);

        Task<List<Client>> GetClientsListWithSubClients();

        Task<Client> GetClient(int ClientId, bool includeChildren);
    }
}
