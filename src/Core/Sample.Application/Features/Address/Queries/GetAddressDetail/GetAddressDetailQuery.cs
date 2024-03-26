using MediatR;

namespace Sample.Application.Features.Addresses.Queries.GetAddressDetail
{
    public class GetAddressDetailQuery : IRequest<AddressDetailVm>
    {
        public int ClientId { get; set; }
    }
}
