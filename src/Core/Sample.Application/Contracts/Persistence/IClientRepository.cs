using Sample.Domain.Entities;

namespace Sample.Application.Contracts.Persistence
{
    public interface IClientRepository : IAsyncRepository<Client>
    {
        Task BulkInsert();

        Task<Client> GetByIdAsync(int id);

        Task<List<Client>> GetClients();

        Task<List<Client>> GetClientsListWithSubClients();

        Task<List<Client>> GetClientsByType(string Type);

        Task<Client> GetClient(int ClientId, bool includeChildren);
    }
}
