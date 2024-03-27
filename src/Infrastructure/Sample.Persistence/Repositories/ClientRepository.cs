using System.Linq.Expressions;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Sample.Application.Contracts.Persistence;
using Sample.Domain.Entities;

namespace Sample.Persistence.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(SampleDbContext dbContext)
            : base(dbContext) { }

        public async Task BulkInsert()
        {
            SeedsBulkUtils factory = new SeedsBulkUtils();

            int clientId = 99;

            var grupoSeeds = Enumerable
                .Range(0, 500) //500
                .Select(s =>
                {
                    clientId++;
                    return new Client
                    {
                        ClientId = clientId,
                        ParentClientId = null,
                        Name = $"Grupo {s}",
                        CurrencyType = "BR",
                        IsStateRegistrationFree = false,
                        Language = "pt-BR",
                        LogoURL = "logo_URL",
                        Origin = "Origem",
                        RegisteredNumber = "000000",
                        StateRegistration = "000000",
                        TimeZone = "Fuso",
                        TradeName = $"Nome {s}",
                        Type = "Grupo",
                        Address = new Address()
                        {
                            Street = $"Street {s}",
                            StreetNumber = "100",
                            City = "City",
                            State = "State",
                            Country = "Country",
                            District = "District",
                            PostalCode = "00000-000",
                            Complement = "Complement"
                        },
                        ChildrenClient =
                        [
                            .. factory.create5ChildrenClients(
                                s,
                                "Grupo/Rede",
                                "Rede",
                                ref clientId,
                                clientId
                            ),
                            .. factory.create5ChildrenClients(
                                s,
                                "Grupo/Parceiro",
                                "Parceiro",
                                ref clientId,
                                clientId
                            ),
                            .. factory.create5ChildrenClients(
                                s,
                                "Grupo/Hotel",
                                "Hotel",
                                ref clientId,
                                clientId
                            ),
                        ]
                    };
                });

            var redeSeeds = Enumerable
                .Range(0, 750) //750
                .Select(s =>
                {
                    clientId++;
                    return new Client
                    {
                        ClientId = clientId,
                        ParentClientId = null,
                        Name = $"Rede {s}",
                        CurrencyType = "BR",
                        IsStateRegistrationFree = false,
                        Language = "pt-BR",
                        LogoURL = "logo_URL",
                        Origin = "Origem",
                        RegisteredNumber = "000000",
                        StateRegistration = "000000",
                        TimeZone = "Fuso",
                        TradeName = $"Nome {s}",
                        Type = "Rede",
                        Address = new Address()
                        {
                            Street = $"Street {s}",
                            StreetNumber = "100",
                            City = "City",
                            State = "State",
                            Country = "Country",
                            District = "District",
                            PostalCode = "00000-000",
                            Complement = "Complement"
                        },
                        ChildrenClient =
                        [
                            .. factory.create5ChildrenClients(
                                s,
                                "Rede/Parceiro",
                                "Parceiro",
                                ref clientId,
                                clientId
                            ),
                            .. factory.create5ChildrenClients(
                                s,
                                "Rede/Hotel",
                                "Hotel",
                                ref clientId,
                                clientId
                            ),
                        ]
                    };
                });

            var parceiroSeeds = Enumerable
                .Range(0, 1000) //1000
                .Select(s =>
                {
                    clientId++;
                    return new Client
                    {
                        ClientId = clientId,
                        ParentClientId = null,
                        Name = $"Parceiro {s}",
                        CurrencyType = "BR",
                        IsStateRegistrationFree = false,
                        Language = "pt-BR",
                        LogoURL = "logo_URL",
                        Origin = "Origem",
                        RegisteredNumber = "000000",
                        StateRegistration = "000000",
                        TimeZone = "Fuso",
                        TradeName = $"Nome {s}",
                        Type = "Parceiro",
                        Address = new Address()
                        {
                            Street = $"Street {s}",
                            StreetNumber = "100",
                            City = "City",
                            State = "State",
                            Country = "Country",
                            District = "District",
                            PostalCode = "00000-000",
                            Complement = "Complement"
                        },
                        ChildrenClient =
                        [
                            .. factory.create5ChildrenClients(
                                s,
                                "Parceiro/Hotel",
                                "Hotel",
                                ref clientId,
                                clientId
                            ),
                        ]
                    };
                });

            var hotelSeeds = Enumerable
                .Range(0, 10000) //10000
                .Select(s =>
                {
                    clientId++;
                    return new Client
                    {
                        ClientId = clientId,
                        ParentClientId = null,
                        Name = $"Hotel {s}",
                        CurrencyType = "BR",
                        IsStateRegistrationFree = false,
                        Language = "pt-BR",
                        LogoURL = "logo_URL",
                        Origin = "Origem",
                        RegisteredNumber = "000000",
                        StateRegistration = "000000",
                        TimeZone = "Fuso",
                        TradeName = $"Nome {s}",
                        Type = "Hotel",
                        Address = new Address()
                        {
                            Street = $"Street {s}",
                            StreetNumber = "100",
                            City = "City",
                            State = "State",
                            Country = "Country",
                            District = "District",
                            PostalCode = "00000-000",
                            Complement = "Complement"
                        },
                        ChildrenClient = []
                    };
                });

            var seeds = grupoSeeds
                .Concat(redeSeeds)
                .Concat(parceiroSeeds)
                .Concat(hotelSeeds)
                .ToList();

            await _dbContext.BulkInsertAsync(
                seeds,
                options =>
                {
                    options.SqlBulkCopyOptions = Microsoft
                        .Data
                        .SqlClient
                        .SqlBulkCopyOptions
                        .KeepIdentity;
                    options.IncludeGraph = true;
                }
            );
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _dbContext.Clients.FindAsync(id);
        }

        public static Expression<Func<Client, Client>> GetClientProjection(
            int maxDepth,
            int currentDepth = 0
        )
        {
            currentDepth++;

            Expression<Func<Client, Client>> result = client => new Client()
            {
                ClientId = client.ClientId,
                Name = client.Name,
                Type = client.Type,
                ParentClientId = client.ParentClientId,
                ChildrenClient =
                    currentDepth == maxDepth
                        ? new List<Client>()
                        : client
                            .ChildrenClient.AsQueryable()
                            .Select(GetClientProjection(maxDepth, currentDepth))
                            .OrderBy(y => y.ClientId)
                            .ToList()
            };

            return result;
        }

        public async Task<Client> GetClient(int ClientId, bool includeChildren)
        {
            if (!includeChildren)
                return await _dbContext.Clients.FirstOrDefaultAsync(c => c.ClientId == ClientId);

            var query = _dbContext
                .Clients.Where(c => c.ClientId == ClientId)
                .Select(GetClientProjection(7, 0))
                .OrderBy(x => x.ClientId)
                .FirstAsync();

            return await query;
        }

        public async Task<List<Client>> GetClients()
        {
            var query = _dbContext.Clients.OrderBy(x => x.ClientId);

            return await query.ToListAsync();
        }

        public async Task<List<Client>> GetClientsListWithSubClients()
        {
            var query = _dbContext
                .Clients.Where(c => c.ParentClient == null)
                .Select(GetClientProjection(7, 0))
                .OrderBy(x => x.ClientId);

            return await query.ToListAsync();
        }

        public async Task<List<Client>> GetClientsByType(string Type)
        {
            var query = _dbContext.Clients.Where(c => c.Type == Type).OrderBy(x => x.ClientId);

            return await query.ToListAsync();
        }

        public async Task<List<IGrouping<string, Client>>> GetClientsGroupByType()
        {
            var query = _dbContext.Clients.GroupBy(c => c.Type).OrderBy(o => o.Key);

            return await query.ToListAsync();
        }
    }
}
