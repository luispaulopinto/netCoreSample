using System;
using System.Collections.Generic;

namespace Sample.Application.Features.Clients.Queries.GetClientWithSubClients
{
    public class ClientListWithSubClientsVm
    {
        public int ClientId { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }
        public ICollection<ClientListWithSubClientsVm> ChildrenClient { get; set; }
    }
}
