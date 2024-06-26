using System.Diagnostics;
using System.Linq.Expressions;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Npgsql.Replication;
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

            int clientId = 0;

            var grupoSeeds = Enumerable
                .Range(0, 1) // 50k option
                // .Range(0, 10000) // 1M option

                //.Range(0, 500) // 50k option
                // .Range(0, 50000) // 1M option
                // .Range(0, 10) // 1M option
                .Select(s =>
                {
                    clientId++;
                    return new Client
                    {
                        Id = clientId,
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
                        ChildrenChain =
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
                .Range(0, 1) // 50k option
                // .Range(0, 15000) // 1M option

                //.Range(0, 750) // 50k option
                // .Range(0, 150000) // 1M option
                // .Range(0, 150) // 1M option
                .Select(s =>
                {
                    clientId++;
                    return new Client
                    {
                        Id = clientId,
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
                        ChildrenChain =
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
                .Range(0, 1) // 50k option
                // .Range(0, 20000) // 1M option

                // .Range(0, 300000) // 1M option
                // .Range(0, 200) // 1M option
                .Select(s =>
                {
                    clientId++;
                    return new Client
                    {
                        Id = clientId,
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
                        ChildrenChain =
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
                .Range(0, 1) // 50k option
                // .Range(0, 200000) // 1M option

                // .Range(0, 10000) // 50k option
                // .Range(0, 500000) // 1M option
                // .Range(0, 200) // 1M option
                .Select(s =>
                {
                    clientId++;
                    return new Client
                    {
                        Id = clientId,
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
                        ChildrenChain = []
                    };
                });

            var seeds = grupoSeeds
                .Concat(redeSeeds)
                .Concat(parceiroSeeds)
                .Concat(hotelSeeds)
                .ToList();

            // _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

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
                Id = client.Id,
                Name = client.Name,
                Type = client.Type,
                ParentClientId = client.ParentClientId,
                ChildrenChain =
                    currentDepth == maxDepth
                        ? new List<Client>()
                        : client
                            .ChildrenChain.AsQueryable()
                            .Select(GetClientProjection(maxDepth, currentDepth))
                            .OrderBy(y => y.Id)
                            .ToList()
            };

            return result;
        }

        public async Task<Client> GetClient(int ClientId, bool includeChildren)
        {
            if (!includeChildren)
                return await _dbContext.Clients.FirstOrDefaultAsync(c => c.Id == ClientId);

            var projectionTimer = new Stopwatch();
            projectionTimer.Start();

            var query = await _dbContext
                .Clients.Where(c => c.Id == ClientId)
                .Select(GetClientProjection(4, 0))
                .OrderBy(x => x.Id)
                .FirstAsync();

            projectionTimer.Stop();

            TimeSpan projectionTimeTaken = projectionTimer.Elapsed;

            var recursiveTimer = new Stopwatch();
            var recursivewiThObjectTimer = new Stopwatch();
            recursiveTimer.Start();
            recursivewiThObjectTimer.Start();

            var recursiveQuery = await _dbContext
                .Clients.FromSql(
                    $@"
                        WITH RECURSIVE recursive_cte
                        AS (
                            -- anchor member
                            SELECT * FROM ""Clients"" 
                                WHERE ""ClientId"" = {ClientId}

                            UNION ALL

                            -- recursive term
                            SELECT c.* FROM ""Clients"" c 
                                INNER JOIN recursive_cte cte 
                                    ON 
                                        cte.""ClientId"" = c.""ParentClientId""
                        ) 
                        
                        SELECT * FROM recursive_cte
                    "
                )
                .ToListAsync();

            recursiveTimer.Stop();

            var lookup = recursiveQuery.ToLookup(x => x.ParentClientId);

            foreach (var c in recursiveQuery)
            {
                if (lookup.Contains(c.Id))
                    c.ChildrenChain.ToList()
                        .AddRange(lookup.Where(s => s.Key == c.Id).SelectMany(x => x));
            }

            // var result = recursiveQuery.Where(c => c.ParentClientId == null).FirstOrDefault();
            var result = recursiveQuery.Where(c => c.Id == ClientId).FirstOrDefault();
            recursivewiThObjectTimer.Stop();

            TimeSpan recursiveTimeTaken = recursiveTimer.Elapsed;
            TimeSpan recursiveWithObjectTimeTaken = recursivewiThObjectTimer.Elapsed;

            Debug.WriteLine(
                "Projection Time taken: " + projectionTimeTaken.ToString(@"m\:ss\.fff")
            );
            Debug.WriteLine("Recursive Time taken: " + recursiveTimeTaken.ToString(@"m\:ss\.fff"));
            Debug.WriteLine(
                "Recursive WITH Object Constructor Time taken: "
                    + recursiveWithObjectTimeTaken.ToString(@"m\:ss\.fff")
            );
            var percentFaster =
                (projectionTimeTaken - recursiveTimeTaken) / projectionTimeTaken * 100;

            Debug.WriteLine(
                "Recursive faster than Projection " + Math.Truncate(percentFaster) + "%"
            );

            return result;
        }

        public async Task<List<Client>> GetClients()
        {
            var query = _dbContext.Clients.OrderBy(x => x.Id).Take(20);

            return await query.ToListAsync();
        }

        public async Task<List<Client>> GetClientsListWithSubClients()
        {
            var query = _dbContext
                .Clients.Where(c => c.ParentClientId == null)
                .Select(GetClientProjection(4, 0))
                .OrderBy(x => x.Id);

            return await query.ToListAsync();
        }

        public async Task<List<Client>> GetClientsByType(string Type)
        {
            var query = _dbContext.Clients.Where(c => c.Type == Type).OrderBy(x => x.Id).Take(20);

            return await query.ToListAsync();
        }

        public async Task<List<IGrouping<string, Client>>> GetClientsGroupByType()
        {
            var query = _dbContext.Clients.GroupBy(c => c.Type).OrderBy(o => o.Key);

            return await query.ToListAsync();
        }
    }
}
