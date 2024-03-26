using Microsoft.EntityFrameworkCore;
using Sample.Application.Contracts.Persistence;
using Sample.Domain.Entities;

namespace Sample.Persistence.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(SampleDbContext dbContext)
            : base(dbContext) { }

        public async Task<Address> GetByClientId(int ClientId)
        {
            return await _dbContext.Address.FirstOrDefaultAsync(c => c.ClientId == ClientId);
        }
    }
}
