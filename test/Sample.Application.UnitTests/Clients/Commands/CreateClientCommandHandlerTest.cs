using AutoMapper;
using Moq;
using Sample.Application.Contracts.Persistence;
using Sample.Application.Features.Clients.Commands.CreateClient;
using Sample.Application.Profiles;
using Sample.Application.UnitTests.Builders;
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
                ClientCommandBuilder.Simple().Build(),
                CancellationToken.None
            );

            var allClients = await _mockClientRepository.Object.GetClientsListWithSubClients();
            allClients.Count.ShouldBe(2);

            newClient.Success.ShouldBeTrue();
        }

        [Fact]
        public async Task NotCreateNewClient_WithoutName()
        {
            var handler = new CreateClientCommandHandler(_mapper, _mockClientRepository.Object);

            var newClient = await handler.Handle(
                ClientCommandBuilder.Simple().WithoutName().Build(),
                CancellationToken.None
            );

            newClient.Success.ShouldBeFalse();
            newClient.ValidationErrors.ShouldHaveSingleItem();
            newClient.ValidationErrors.First().ShouldBe("Name is required.");
        }

        [Fact]
        public async Task NotCreateNewClient_WithoutType()
        {
            var handler = new CreateClientCommandHandler(_mapper, _mockClientRepository.Object);

            var newClient = await handler.Handle(
                ClientCommandBuilder.Simple().WithoutType().Build(),
                CancellationToken.None
            );

            newClient.Success.ShouldBeFalse();
            newClient.ValidationErrors.ShouldHaveSingleItem();
            newClient.ValidationErrors.First().ShouldBe("Type is required.");
        }

        [Fact]
        public async Task NotCreateNewClient_WithoutRegisteredNumber()
        {
            var handler = new CreateClientCommandHandler(_mapper, _mockClientRepository.Object);

            var newClient = await handler.Handle(
                ClientCommandBuilder.Simple().WithRegisteredNumber("").Build(),
                CancellationToken.None
            );

            newClient.Success.ShouldBeFalse();
            newClient.ValidationErrors.ShouldHaveSingleItem();
            newClient.ValidationErrors.First().ShouldBe("Registered Number is required.");
        }

        [Fact]
        public async Task NotCreateNewClient_WithoutLanguage()
        {
            var handler = new CreateClientCommandHandler(_mapper, _mockClientRepository.Object);

            var newClient = await handler.Handle(
                ClientCommandBuilder.Simple().WithLanguage("").Build(),
                CancellationToken.None
            );

            newClient.Success.ShouldBeFalse();
            newClient.ValidationErrors.ShouldHaveSingleItem();
            newClient.ValidationErrors.First().ShouldBe("Language is required.");
        }

        [Fact]
        public async Task NotCreateNewClient_WithoutCurrencyType()
        {
            var handler = new CreateClientCommandHandler(_mapper, _mockClientRepository.Object);

            var newClient = await handler.Handle(
                ClientCommandBuilder.Simple().WithCurrencyType("").Build(),
                CancellationToken.None
            );

            newClient.Success.ShouldBeFalse();
            newClient.ValidationErrors.ShouldHaveSingleItem();
            newClient.ValidationErrors.First().ShouldBe("Currency Type is required.");
        }

        [Fact]
        public async Task NotCreateNewClient_WithoutTimeZone()
        {
            var handler = new CreateClientCommandHandler(_mapper, _mockClientRepository.Object);

            var newClient = await handler.Handle(
                ClientCommandBuilder.Simple().WithTimeZone("").Build(),
                CancellationToken.None
            );

            newClient.Success.ShouldBeFalse();
            newClient.ValidationErrors.ShouldHaveSingleItem();
            newClient.ValidationErrors.First().ShouldBe("Time Zone is required.");
        }
    }
}
