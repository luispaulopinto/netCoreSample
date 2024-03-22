using AutoMapper;
using MediatR;
using Sample.Application.Contracts.Persistence;

namespace Sample.Application.Features.Clients.Commands.DeleteClient
{
    public class UpdateClientCommandHandler : IRequestHandler<DeleteClientCommand>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public UpdateClientCommandHandler(IMapper mapper, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var clientDetail = await _clientRepository.GetClient(request.ClientId, true);

            // var eventToDelete = await _clientRepository.GetByIdAsync(request.ClientId);

            await _clientRepository.DeleteAsync(clientDetail);
        }
    }
}
