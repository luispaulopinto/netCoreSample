using AutoMapper;
using MediatR;
using Sample.Application.Contracts.Persistence;
using Sample.Domain.Entities;

namespace Sample.Application.Features.Clients.Queries.GetClients
{
    public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, List<ClientsListVm>>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public GetClientsQueryHandler(IMapper mapper, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task<List<ClientsListVm>> Handle(
            GetClientsQuery request,
            CancellationToken cancellationToken
        )
        {
            List<Client> list;

            if (string.IsNullOrEmpty(request.Type))
                list = await _clientRepository.GetClients();
            else
                list = await _clientRepository.GetClientsByType(request.Type);

            return _mapper.Map<List<ClientsListVm>>(list);
        }
    }
}
