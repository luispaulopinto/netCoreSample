using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using Sample.Application.Contracts.Persistence;
using Sample.Domain.Entities;

namespace Sample.Application.Features.Clients.Queries.GetClientWithSubClients
{
    public class GetClientsWithSubClientsQueryHandler
        : IRequestHandler<GetClientsWithSubClientsQuery, List<ClientListWithSubClientsVm>>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public GetClientsWithSubClientsQueryHandler(
            IMapper mapper,
            IClientRepository clientRepository
        )
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task<List<ClientListWithSubClientsVm>> Handle(
            GetClientsWithSubClientsQuery request,
            CancellationToken cancellationToken
        )
        {
            List<Client> list = [];

            if (string.IsNullOrEmpty(request.Type))
                list = await _clientRepository.GetClientsListWithSubClients();
            else
                list = await _clientRepository.GetClientsByType(request.Type);

            return _mapper.Map<List<ClientListWithSubClientsVm>>(list);
        }
    }
}
