using Sample.Application.Contracts.Persistence;
using Sample.Domain.Entities;

namespace Sample.Persistence.Repositories
{
    public class ClientRepository : BaseRepository<Event>, IClientRepository
    {
        public ClientRepository(SampleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
