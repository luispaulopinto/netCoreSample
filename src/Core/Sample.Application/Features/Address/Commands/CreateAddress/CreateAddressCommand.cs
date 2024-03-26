using MediatR;

namespace Sample.Application.Features.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommand : IRequest<CreateAddressCommandResponse>
    {
        public int ClientId { get; set; }
        public string Street { get; set; } = string.Empty;
    }
}
