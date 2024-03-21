using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sample.Application.Contracts.Persistence;
using Sample.Domain.Entities;

namespace Sample.Persistence.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(SampleDbContext dbContext) : base(dbContext)
        {
        }

        public static Expression<Func<Client, Client>> GetClientProjection(int maxDepth, int currentDepth = 0)
        {
            currentDepth++;

            Expression<Func<Client, Client>> result = client => new Client()
            {
                ClientId = client.ClientId,
                Name = client.Name,
                Type = client.Type,
                ParentClientId = client.ParentClientId,
                ChildrenClient = currentDepth == maxDepth ? new List<Client>()
                : client.ChildrenClient.AsQueryable().Select(GetClientProjection(maxDepth, currentDepth)).OrderBy(y => y.ClientId).ToList()
            };

            return result;

        }

        public async Task<Client> GetClient(int ClientId, bool includeChildren)
        {
            if (!includeChildren)
                return await _dbContext.Clients.FirstOrDefaultAsync(c => c.ClientId == ClientId);

            var query = _dbContext.Clients.Where(c => c.ClientId == ClientId).Select(GetClientProjection(7, 0)).OrderBy(x => x.ClientId).FirstAsync();

            return await query;
        }


        public async Task<List<Client>> GetClientsListWithSubClients()
        {
            var query = _dbContext.Clients.Where(c => c.ParentClient == null).Select(GetClientProjection(7, 0)).OrderBy(x => x.ClientId);

            return await query.ToListAsync();
        }       
    }
}
