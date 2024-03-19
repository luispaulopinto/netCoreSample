using AutoMapper;
using MediatR;
using Sample.Application.Contracts.Persistence;

namespace Sample.Application.Features.Clients.Queries.GetClientDetail
{
    public class GetClientDetailQueryHandler : IRequestHandler<GetClientDetailQuery, ClientDetailVm>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public GetClientDetailQueryHandler(IMapper mapper, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task<ClientDetailVm> Handle(GetClientDetailQuery request, CancellationToken cancellationToken)
        {
            var clientDetail = await _clientRepository.GetClient(request.ClientId, request.IncludeChildren);
            return _mapper.Map<ClientDetailVm>(clientDetail);
        }
    }
}
