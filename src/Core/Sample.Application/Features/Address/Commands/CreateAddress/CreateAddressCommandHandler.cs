using AutoMapper;
using MediatR;
using Sample.Application.Contracts.Persistence;
using Sample.Domain.Entities;

namespace Sample.Application.Features.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommandHandler
        : IRequestHandler<CreateAddressCommand, CreateAddressCommandResponse>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public CreateAddressCommandHandler(IMapper mapper, IAddressRepository AddressRepository)
        {
            _mapper = mapper;
            _addressRepository = AddressRepository;
        }

        public async Task<CreateAddressCommandResponse> Handle(
            CreateAddressCommand request,
            CancellationToken cancellationToken
        )
        {
            var createAddressCommandResponse = new CreateAddressCommandResponse();

            var validator = new CreateAddressCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createAddressCommandResponse.Success = false;
                createAddressCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createAddressCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createAddressCommandResponse.Success)
            {
                var address = new Address() { Street = request.Street };
                address = await _addressRepository.AddAsync(address);
                createAddressCommandResponse.Address = _mapper.Map<CreateAddressDto>(address);
            }

            return createAddressCommandResponse;
        }
    }
}
