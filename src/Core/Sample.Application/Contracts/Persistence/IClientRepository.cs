using Sample.Domain.Entities;

namespace Sample.Application.Contracts.Persistence
{
    public interface IClientRepository : IAsyncRepository<Event>
    {
        
    }
}
