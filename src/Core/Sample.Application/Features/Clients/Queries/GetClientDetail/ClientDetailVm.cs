using System;
using System.Collections.Generic;

namespace Sample.Application.Features.Clients.Queries.GetClientDetail
{
    public class ClientDetailVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int ParentId { get; set; }
        public ICollection<ClientDetailVm> ChildrenClient { get; set; }
    }
}
