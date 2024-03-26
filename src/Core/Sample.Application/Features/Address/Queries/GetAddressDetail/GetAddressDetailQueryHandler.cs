using AutoMapper;
using MediatR;
using Sample.Application.Contracts.Persistence;

namespace Sample.Application.Features.Addresses.Queries.GetAddressDetail
{
    public class GetAddressDetailQueryHandler
        : IRequestHandler<GetAddressDetailQuery, AddressDetailVm>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public GetAddressDetailQueryHandler(IMapper mapper, IAddressRepository AddressRepository)
        {
            _mapper = mapper;
            _addressRepository = AddressRepository;
        }

        public async Task<AddressDetailVm> Handle(
            GetAddressDetailQuery request,
            CancellationToken cancellationToken
        )
        {
            var AddressDetail = await _addressRepository.GetByClientId(request.ClientId);

            return _mapper.Map<AddressDetailVm>(AddressDetail);
        }
    }
}
