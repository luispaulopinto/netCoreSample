using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sample.Application.Features.Clients.Queries.GetClientWithSubClients
{
    public class ClientListWithSubClientsVm
    {
        public int ClientId { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICollection<ClientListWithSubClientsVm> ChildrenClient { get; set; }
    }
}
