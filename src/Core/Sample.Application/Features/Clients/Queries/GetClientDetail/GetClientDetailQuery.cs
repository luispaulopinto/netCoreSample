using MediatR;

namespace Sample.Application.Features.Clients.Queries.GetClientDetail
{
    public class GetClientDetailQuery : IRequest<ClientDetailVm>
    {
        public int ClientId { get; set; }
        public bool IncludeChildren { get; set; }
    }
}