using AutoMapper;

using Sample.Application.Contracts.Persistence;
using Sample.Domain.Entities;
using MediatR;
using System.Linq.Expressions;

namespace Sample.Application.Features.Clients.Queries.GetClientWithSubClients
{
    public class GetClientsWithSubClientsQueryHandler : IRequestHandler<GetClientsWithSubClientsQuery, List<ClientListWithSubClientsVm>>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public GetClientsWithSubClientsQueryHandler(IMapper mapper, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task<List<ClientListWithSubClientsVm>> Handle(GetClientsWithSubClientsQuery request, CancellationToken cancellationToken)
        {
            var list = await _clientRepository.GetClientsListWithSubClients();
            return _mapper.Map<List<ClientListWithSubClientsVm>>(list);
        }
    }




}
