using AutoMapper;
using MediatR;
using Sample.Application.Contracts.Persistence;
using Sample.Application.Features.Clients.Commands.CreateClient;

namespace Sample.Application.Features.Clients.Commands.DeleteClient
{
    public class CreateSeedsCommandHandler : IRequestHandler<CreateSeedsCommand>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public CreateSeedsCommandHandler(IMapper mapper, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task Handle(CreateSeedsCommand request, CancellationToken cancellationToken)
        {
            await _clientRepository.BulkInsert();
        }
    }
}
