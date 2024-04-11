using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sample.Application.Features.Clients.Queries.GetClients
{
    public class ClientsListVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }
    }
}
