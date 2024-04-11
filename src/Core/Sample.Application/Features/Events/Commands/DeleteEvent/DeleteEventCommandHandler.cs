// using AutoMapper;
// using MediatR;
// using Sample.Application.Contracts.Persistence;
// using Sample.Domain.Entities;

// namespace Sample.Application.Features.Events.Commands.DeleteEvent
// {
//     public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
//     {
//         private readonly IAsyncRepository<Event> _eventRepository;
//         private readonly IMapper _mapper;

//         public DeleteEventCommandHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
//         {
//             _mapper = mapper;
//             _eventRepository = eventRepository;
//         }

//         public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
//         {
//             var eventToDelete = await _eventRepository.GetByIdAsync(request.EventId);

//             await _eventRepository.DeleteAsync(eventToDelete);
//         }
//     }
// }
