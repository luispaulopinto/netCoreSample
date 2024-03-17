using Sample.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Sample.Identity
{
    public class SampleIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public SampleIdentityDbContext()
        {

        }

        public SampleIdentityDbContext(DbContextOptions<SampleIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
        .LogTo(Console.WriteLine)
        .EnableSensitiveDataLogging();

    }
}
