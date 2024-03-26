using Sample.Domain.Entities;

namespace Sample.Application.Contracts.Persistence
{
    public interface IAddressRepository : IAsyncRepository<Address>
    {
        Task<Address> GetByClientId(int clientId);
    }
}
