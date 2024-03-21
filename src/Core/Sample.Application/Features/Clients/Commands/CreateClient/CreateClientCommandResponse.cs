using Sample.Application.Responses;

namespace Sample.Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientCommandResponse : BaseResponse
    {
        public CreateClientCommandResponse() : base()
        {

        }

        public CreateClientDto Client { get; set; } = default!;
    }
}