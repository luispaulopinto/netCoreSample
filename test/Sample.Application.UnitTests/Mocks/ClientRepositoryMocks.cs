﻿using Moq;
using Sample.Application.Contracts.Persistence;
using Sample.Domain.Entities;

namespace Sample.Application.UnitTests.Mocks
{
    public class ClientRepositoryMocks
    {
        public static Mock<IClientRepository> GetClientRepository()
        {
            var clients = new List<Client>
            {
                new Client
                {
                    ClientId = 1,
                    Name = "Grupo AAAA",
                    ParentClientId = null,
                    Type = "Grupo",
                    ChildrenClient =
                    [
                        new Client
                        {
                            ClientId = 2,
                            Name = "Rede AAAA",
                            ParentClientId = 1,
                            Type = "Rede",
                            ChildrenClient =
                            [
                                new Client
                                {
                                    ClientId = 3,
                                    Name = "Parceiro  AAAA",
                                    ParentClientId = 2,
                                    Type = "Parceiro",
                                    ChildrenClient =
                                    [
                                        new Client
                                        {
                                            ClientId = 4,
                                            Name = "Hotel  AAAA1",
                                            ParentClientId = 3,
                                            Type = "Hotel"
                                        },
                                        new Client
                                        {
                                            ClientId = 5,
                                            Name = "Hotel  AAAA1",
                                            ParentClientId = 3,
                                            Type = "Hotel"
                                        },
                                    ]
                                },
                            ]
                        },
                    ]
                },
            };

            var mockClientRepository = new Mock<IClientRepository>();

            mockClientRepository
                .Setup(repo => repo.GetClientsListWithSubClients())
                .ReturnsAsync(clients);

            mockClientRepository
                .Setup(repo => repo.AddAsync(It.IsAny<Client>()))
                .ReturnsAsync(
                    (Client client) =>
                    {
                        clients.Add(client);
                        return client;
                    }
                );

            return mockClientRepository;
        }
    }
}
