using AutoMapper;
using Sample.Application.Contracts.Persistence;
using Sample.Application.Features.Clients.Queries.GetClientWithSubClients;
using Sample.Application.Profiles;
using Sample.Application.UnitTests.Mocks;
using Sample.Domain.Entities;
using Moq;
using Shouldly;

namespace Sample.Application.UnitTests.Categories.Queries
{
    // dotnet test --filter Category=CLients
    // dotnet test --filter "Category=CLients|Category=xxx"
    [Trait("Category", "Clients")]
    public class GetClientsWithSubClientsQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IClientRepository> _mockClientsRepository;

        public GetClientsWithSubClientsQueryHandlerTests()
        {
            _mockClientsRepository = ClientRepositoryMocks.GetClientRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        // [Fact(Skip = 'dont run')]
        public async Task GetCategoriesListTest()
        {
            var handler = new GetClientsWithSubClientsQueryHandler(_mapper, _mockClientsRepository.Object);

            var result = await handler.Handle(new GetClientsWithSubClientsQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<ClientListWithSubClientsVm>>();

            result.Count.ShouldBe(5);
        }
    }
}
