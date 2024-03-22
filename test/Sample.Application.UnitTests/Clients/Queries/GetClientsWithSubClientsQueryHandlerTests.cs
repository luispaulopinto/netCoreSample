using AutoMapper;
using Moq;
using Sample.Application.Contracts.Persistence;
using Sample.Application.Features.Clients.Queries.GetClientWithSubClients;
using Sample.Application.Profiles;
using Sample.Application.UnitTests.Mocks;
using Sample.Domain.Entities;
using Shouldly;

namespace Sample.Application.UnitTests.Categories.Queries
{
    public class GetClientsWithSubClientsQueryHandlerShould
    {
        private readonly IMapper _mapper;
        private readonly Mock<IClientRepository> _mockClientsRepository;

        public GetClientsWithSubClientsQueryHandlerShould()
        {
            _mockClientsRepository = ClientRepositoryMocks.GetClientRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task ListClientsWithSubClient()
        {
            var handler = new GetClientsWithSubClientsQueryHandler(
                _mapper,
                _mockClientsRepository.Object
            );

            var result = await handler.Handle(
                new GetClientsWithSubClientsQuery(),
                CancellationToken.None
            );

            result.ShouldBeOfType<List<ClientListWithSubClientsVm>>();

            result.Count.ShouldBe(1);
            result.First().ChildrenClient.Count.ShouldBe(1);
            result.First().ChildrenClient.First().ChildrenClient.Count.ShouldBe(1);
            result
                .First()
                .ChildrenClient.First()
                .ChildrenClient.First()
                .ChildrenClient.Count.ShouldBe(2);
        }
    }
}
