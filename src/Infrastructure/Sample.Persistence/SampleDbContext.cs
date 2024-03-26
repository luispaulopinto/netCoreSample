using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sample.Application.Contracts;
using Sample.Domain.Common;
using Sample.Domain.Entities;

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

        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SampleDbContext).Assembly);

            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 1,
                        Name = "Grupo AAAA",
                        TradeName = "Grupo AAAA",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = null,
                        Type = "Grupo"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 2,
                        Name = "Rede AAAA",
                        TradeName = "Rede AAAA",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 1,
                        Type = "Rede"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 3,
                        Name = "Parceiro  AAAA",
                        TradeName = "Parceiro  AAAA",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 2,
                        Type = "Parceiro"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 4,
                        Name = "Hotel  AAAA1",
                        TradeName = "Hotel  AAAA1",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 3,
                        Type = "Hotel"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 5,
                        Name = "Hotel  AAAA1",
                        TradeName = "Hotel  AAAA1",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 3,
                        Type = "Hotel"
                    }
                );

            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 42,
                        Name = "Rede AAAB",
                        TradeName = "Rede AAAB",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 1,
                        Type = "Rede"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 43,
                        Name = "Parceiro  AAAB",
                        TradeName = "Parceiro  AAAB",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 42,
                        Type = "Parceiro"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 44,
                        Name = "Hotel  AAAB",
                        TradeName = "Hotel  AAAB",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 43,
                        Type = "Hotel"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 45,
                        Name = "Hotel  AAAB",
                        TradeName = "Hotel  AAAB",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 43,
                        Type = "Hotel"
                    }
                );

            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 6,
                        Name = "Grupo BBBB",
                        TradeName = "Grupo BBBB",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = null,
                        Type = "Grupo"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 7,
                        Name = "Rede BBBB",
                        TradeName = "Rede BBBB",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 6,
                        Type = "Rede"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 8,
                        Name = "Parceiro  BBBB",
                        TradeName = "Parceiro  BBBB",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 7,
                        Type = "Parceiro"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 9,
                        Name = "Hotel  BBBB1",
                        TradeName = "Hotel  BBBB1",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 8,
                        Type = "Hotel"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 10,
                        Name = "Hotel  BBBB1",
                        TradeName = "Hotel  BBBB1",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 8,
                        Type = "Hotel"
                    }
                );

            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 47,
                        Name = "Parceiro  BBBC",
                        TradeName = "Parceiro  BBBC",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 6,
                        Type = "Parceiro"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 48,
                        Name = "Hotel  BBBC1",
                        TradeName = "Hotel  BBBC1",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 47,
                        Type = "Hotel"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 49,
                        Name = "Hotel  BBBC1",
                        TradeName = "Hotel  BBBC1",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 47,
                        Type = "Hotel"
                    }
                );

            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 11,
                        Name = "Grupo CCCC",
                        TradeName = "Grupo CCCC",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = null,
                        Type = "Grupo"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 12,
                        Name = "Rede CCCC",
                        TradeName = "Rede CCCC",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 11,
                        Type = "Rede"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 13,
                        Name = "Parceiro  CCCC",
                        TradeName = "Parceiro  CCCC",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 12,
                        Type = "Parceiro"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 14,
                        Name = "Hotel  CCCC1",
                        TradeName = "Hotel  CCCC1",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 13,
                        Type = "Hotel"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 15,
                        Name = "Hotel  CCCC1",
                        TradeName = "Hotel  CCCC1",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 13,
                        Type = "Hotel"
                    }
                );

            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 50,
                        Name = "Parceiro  CCCD",
                        TradeName = "Parceiro  CCCD",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 12,
                        Type = "Parceiro"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 51,
                        Name = "Hotel  CCCD1",
                        TradeName = "Hotel  CCCD1",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 50,
                        Type = "Hotel"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 52,
                        Name = "Hotel  CCCD1",
                        TradeName = "Hotel  CCCD1",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 50,
                        Type = "Hotel"
                    }
                );

            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 16,
                        Name = "Grupo DDDD",
                        TradeName = "Grupo DDDD",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = null,
                        Type = "Grupo"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 17,
                        Name = "Rede DDDD",
                        TradeName = "Rede DDDD",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 16,
                        Type = "Rede"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 18,
                        Name = "Parceiro  DDDD",
                        TradeName = "Parceiro  DDDD",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 17,
                        Type = "Parceiro"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 19,
                        Name = "Hotel  DDDD1",
                        TradeName = "Hotel  DDDD1",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 18,
                        Type = "Hotel"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 20,
                        Name = "Hotel  DDDD1",
                        TradeName = "Hotel  DDDD1",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 18,
                        Type = "Hotel"
                    }
                );

            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 53,
                        Name = "Hotel  DDDE1",
                        TradeName = "Hotel  DDDE1",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 16,
                        Type = "Hotel"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 54,
                        Name = "Hotel  DDDE1",
                        TradeName = "Hotel  DDDE1",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 16,
                        Type = "Hotel"
                    }
                );

            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 21,
                        Name = "Grupo EEEE",
                        TradeName = "Grupo EEEE",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = null,
                        Type = "Grupo"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 22,
                        Name = "Rede EEEE",
                        TradeName = "Rede EEEE",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 21,
                        Type = "Rede"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 23,
                        Name = "Parceiro  EEEE",
                        TradeName = "Parceiro  EEEE",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 22,
                        Type = "Parceiro"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 24,
                        Name = "Hotel  EEEE1",
                        TradeName = "Hotel  EEEE1",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 23,
                        Type = "Hotel"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 25,
                        Name = "Hotel  EEEE1",
                        TradeName = "Hotel  EEEE1",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 23,
                        Type = "Hotel"
                    }
                );

            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 26,
                        Name = "Rede AAA",
                        TradeName = "Rede AAA",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = null,
                        Type = "Rede"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 27,
                        Name = "Parceiro  AAA",
                        TradeName = "Parceiro  AAA",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 26,
                        Type = "Parceiro"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 28,
                        Name = "Hotel  AAA1",
                        TradeName = "Hotel  AAA1",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 27,
                        Type = "Hotel"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 29,
                        Name = "Hotel  AAA1",
                        TradeName = "Hotel  AAA1",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 27,
                        Type = "Hotel"
                    }
                );

            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 30,
                        Name = "Rede BBB",
                        TradeName = "Rede BBB",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = null,
                        Type = "Rede"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 31,
                        Name = "Parceiro  BBB",
                        TradeName = "Parceiro  BBB",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 30,
                        Type = "Parceiro"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 32,
                        Name = "Hotel  BBB1",
                        TradeName = "Hotel  BBB1",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 31,
                        Type = "Hotel"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 33,
                        Name = "Hotel  BBB1",
                        TradeName = "Hotel  BBB1",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 31,
                        Type = "Hotel"
                    }
                );

            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 34,
                        Name = "Parceiro  AA",
                        TradeName = "Parceiro  AA",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = null,
                        Type = "Parceiro"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 35,
                        Name = "Hotel  AA1",
                        TradeName = "Hotel  AA1",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 34,
                        Type = "Hotel"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 36,
                        Name = "Hotel  AA1",
                        TradeName = "Hotel  AA1",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 34,
                        Type = "Hotel"
                    }
                );

            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 37,
                        Name = "Parceiro  BB",
                        TradeName = "Parceiro  BB",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = null,
                        Type = "Parceiro"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 38,
                        Name = "Hotel  BB1",
                        TradeName = "Hotel  BB1",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 37,
                        Type = "Hotel"
                    }
                );
            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 39,
                        Name = "Hotel  BB1",
                        TradeName = "Hotel  BB1",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = 37,
                        Type = "Hotel"
                    }
                );

            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 40,
                        Name = "Hotel  A1",
                        TradeName = "Hotel  A1",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = null,
                        Type = "Hotel"
                    }
                );

            modelBuilder
                .Entity<Client>()
                .HasData(
                    new Client
                    {
                        ClientId = 41,
                        Name = "Hotel  B1",
                        TradeName = "Hotel  B1",
                        RegisteredNumber = "000",
                        LogoURL = "LogoURL",
                        Language = "BR",
                        CurrencyType = "REAL",
                        Origin = "Origem",
                        StateRegistration = "00000",
                        TimeZone = "Brasilia",
                        IsStateRegistrationFree = false,
                        ParentClientId = null,
                        Type = "Hotel"
                    }
                );
        }

        public override Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = new CancellationToken()
        )
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
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
