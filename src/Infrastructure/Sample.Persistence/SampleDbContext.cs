using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sample.Application.Contracts;
using Sample.Domain.Common;
using Sample.Domain.Entities;
using Sample.Domain.Interfaces;

namespace Sample.Persistence
{
    public class SampleDbContext : DbContext
    {
        private readonly ILoggedInUserService? _loggedInUserService;

        public SampleDbContext(DbContextOptions<SampleDbContext> options)
            : base(options) { }

        public SampleDbContext(
            DbContextOptions<SampleDbContext> options,
            ILoggedInUserService loggedInUserService
        )
            : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }

        // public DbSet<Event> Events { get; set; }
        // public DbSet<Category> Categories { get; set; }
        // public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Address { get; set; }

        public DbSet<Department> Department { get; set; }
        public DbSet<Contact> Contact { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SampleDbContext).Assembly);

            // modelBuilder
            //     .Entity<Client>()
            //     .HasOne(e => e.InvoicingAddres)
            //     .WithOne(e => e.Client)
            //     .HasForeignKey<InvoicingAddress>(e => e.ClientId)
            //     .IsRequired();

            // modelBuilder.Entity<Client>().HasOne(e => e.ParentClient);

            // modelBuilder.Entity<Country>();


            modelBuilder.Entity<Client>().HasKey(k => k.Id);

            modelBuilder
                .Entity<Client>()
                .HasOne(e => e.ParentClient)
                .WithMany(e => e.ChildrenChain)
                .HasForeignKey(e => e.ParentClientId);

            modelBuilder
                .Entity<Country>()
                .HasOne(e => e.Continent)
                .WithMany(e => e.Countries)
                .HasPrincipalKey(e => e.ISOCode)
                .HasForeignKey(e => e.ContinentIsoCode)
                .IsRequired();

            // modelBuilder
            //     .Entity<State>()
            //     .HasOne(e => e.Country)
            //     .WithMany(e => e.States)
            //     .HasForeignKey(e => e.CountryId)
            //     .HasForeignKey(e => e.CountryCode)
            //     .IsRequired();

            // modelBuilder
            //     .Entity<City>()
            //     .HasOne(e => e.State)
            //     .WithMany(e => e.Cities)
            //     .HasForeignKey(e => e.Admin1Code)
            //     .IsRequired();
        }

        public override Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = new CancellationToken()
        )
        {
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}


//dotnet ef database update --verbose --project src/Infrastructure/Sample.Persistence --startup-project src/API/Sample.API  --context SampleDbContext
//dotnet ef migrations add --verbose --project src/Infrastructure/Sample.Persistence --startup-project src/API/Sample.API  --context SampleDbContext -v Create_
