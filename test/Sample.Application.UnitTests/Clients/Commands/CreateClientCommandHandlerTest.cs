using AutoMapper;
using Moq;
using Sample.Application.Contracts.Persistence;
using Sample.Application.Features.Clients.Commands.CreateClient;
using Sample.Application.Profiles;
using Sample.Application.UnitTests.Mocks;
using Shouldly;

namespace Sample.Application.UnitTests.Clients.Commands
{
    public class CreateClientCommandHandlerShould
    {
        private readonly IMapper _mapper;
        private readonly Mock<IClientRepository> _mockClientRepository;

        public CreateClientCommandHandlerShould()
        {
            _mockClientRepository = ClientRepositoryMocks.GetClientRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task CreateNewClient()
        {
            var handler = new CreateClientCommandHandler(_mapper, _mockClientRepository.Object);

            var newClient = await handler.Handle(
                new CreateClientCommand() { Name = "New Client", Type = "Grupo" },
                CancellationToken.None
            );

            var allClients = await _mockClientRepository.Object.GetClientsListWithSubClients();
            allClients.Count.ShouldBe(2);

            newClient.Success.ShouldBeTrue();
        }

        [Fact]
        public async Task NotCreateNewClient_WithoutType()
        {
            var handler = new CreateClientCommandHandler(_mapper, _mockClientRepository.Object);

            var newClient = await handler.Handle(
                new CreateClientCommand() { Name = "New Client" },
                CancellationToken.None
            );

            // var allClients = await _mockClientRepository.Object.GetClientsListWithSubClients();
            // allClients.Count.ShouldBe(2);

            newClient.Success.ShouldBeFalse();
        }
    }
}
