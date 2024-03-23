using AutoMapper;
using MediatR;
using Sample.Application.Contracts.Persistence;
using Sample.Domain.Entities;

namespace Sample.Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientCommandHandler
        : IRequestHandler<CreateClientCommand, CreateClientCommandResponse>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public CreateClientCommandHandler(IMapper mapper, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task<CreateClientCommandResponse> Handle(
            CreateClientCommand request,
            CancellationToken cancellationToken
        )
        {
            var createClientCommandResponse = new CreateClientCommandResponse();

            var validator = new CreateClientCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createClientCommandResponse.Success = false;
                createClientCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createClientCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createClientCommandResponse.Success)
            {
                var client = new Client() { Name = request.Name, Type = request.Type };
                client = await _clientRepository.AddAsync(client);
                createClientCommandResponse.Client = _mapper.Map<CreateClientDto>(client);
            }

            return createClientCommandResponse;
        }
    }
}
