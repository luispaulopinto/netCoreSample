using Microsoft.EntityFrameworkCore;
using Moq;
using Sample.Application.Contracts;
using Sample.Domain.Entities;
using Shouldly;

namespace Sample.Persistence.IntegrationTests
{
    public class SampleDbContextTests
    {
        private readonly SampleDbContext _sampleDbContext;
        private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
        private readonly string _loggedInUserId;

        public SampleDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<SampleDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _loggedInUserId = "00000000-0000-0000-0000-000000000000";
            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            _loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

            _sampleDbContext = new SampleDbContext(
                dbContextOptions,
                _loggedInUserServiceMock.Object
            );
        }

        [Fact]
        public async void Save_SetCreatedByProperty()
        {
            var ev = new Event() { Id = Guid.NewGuid(), Name = "Test event" };

            // _sampleDbContext.Events.Add(ev);
            await _sampleDbContext.SaveChangesAsync();

            ev.CreatedBy.ShouldBe(_loggedInUserId);
        }
    }
}
