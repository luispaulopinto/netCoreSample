using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.API;
using Sample.Application.Features.Addresses.Commands.CreateAddress;
using Sample.Application.Features.Clients.Commands.CreateClient;
using Sample.Application.Features.Clients.Commands.DeleteClient;
using Sample.Application.Features.Clients.Commands.UpdateClient;
using Sample.Application.Features.Clients.Queries.GetClientDetail;
using Sample.Application.Features.Clients.Queries.GetClients;
using Sample.Application.Features.Clients.Queries.GetClientWithSubClients;

namespace Sample.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllClients")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ClientsListVm>>> GetAllClients(string? type)
        {
            var dtos = await _mediator.Send(new GetClientsQuery() { Type = type ?? string.Empty });
            return Ok(new PagedResponse<List<ClientsListVm>>(dtos, 1, 20));
        }

        [HttpGet("withsubclients", Name = "GetAllClientsWithSubClients")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<
            ActionResult<List<ClientListWithSubClientsVm>>
        > GetAllClientsWithSubClients()
        {
            var dtos = await _mediator.Send(new GetClientsWithSubClientsQuery() { });
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetClientById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ClientDetailVm>>> GetClientDetail(
            int id,
            bool includeChildren
        )
        {
            var getClientDetail = new GetClientDetailQuery()
            {
                ClientId = id,
                IncludeChildren = includeChildren
            };

            return Ok(await _mediator.Send(getClientDetail));
        }

        [HttpPost(Name = "AddClient")]
        public async Task<ActionResult<CreateClientCommandResponse>> Create(
            [FromBody] CreateClientCommand createClientCommand
        // [FromBody] CreateAddressCommand createAddressCommand
        )
        {
            var clientResponse = await _mediator.Send(createClientCommand);

            // createAddressCommand.ClientId = clientResponse.Client.ClientId;
            // var addressResponse = await _mediator.Send(createAddressCommand);

            return Ok(clientResponse);
        }

        [HttpPost("BulkInsert 50k", Name = "BulkInsert")]
        public async Task<ActionResult> Create(
            [FromBody] CreateSeedsCommand createSeedsCommand
        // [FromBody] CreateAddressCommand createAddressCommand
        )
        {
            await _mediator.Send(createSeedsCommand);

            return NoContent();
        }

        [HttpPut(Name = "UpdateClient")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateClientCommand updateClientCommand)
        {
            await _mediator.Send(updateClientCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteClient")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteEventCommand = new DeleteClientCommand() { ClientId = id };
            await _mediator.Send(deleteEventCommand);
            return NoContent();
        }
    }
}
