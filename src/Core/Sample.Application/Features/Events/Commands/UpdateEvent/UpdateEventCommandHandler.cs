using AutoMapper;
using MediatR;
using Sample.Application.Contracts.Persistence;
using Sample.Application.Exceptions;
using Sample.Domain.Entities;

namespace Sample.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IMapper _mapper;

        public UpdateEventCommandHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var clientToUpdate = await _eventRepository.GetByIdAsync(request.EventId);

            _mapper.Map(request, clientToUpdate, typeof(UpdateEventCommand), typeof(Event));

            await _eventRepository.UpdateAsync(clientToUpdate);
        }
    }
}
