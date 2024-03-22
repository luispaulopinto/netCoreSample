using AutoMapper;
using MediatR;
using Sample.Application.Contracts.Persistence;
using Sample.Application.Exceptions;
using Sample.Domain.Entities;

namespace Sample.Application.Features.Clients.Commands.UpdateClient
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public UpdateClientCommandHandler(IMapper mapper, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var clientToUpdate = await _clientRepository.GetByIdAsync(request.ClientId);

            if (clientToUpdate == null)
                throw new NotFoundException("Client");

            _mapper.Map(request, clientToUpdate, typeof(UpdateClientCommand), typeof(Client));

            await _clientRepository.UpdateAsync(clientToUpdate);
        }
    }
}
