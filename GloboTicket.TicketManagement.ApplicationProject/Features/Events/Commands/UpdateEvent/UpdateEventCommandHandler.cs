using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, UpdateEventCommandResponse>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public UpdateEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<UpdateEventCommandResponse> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var updateEventCommandResponse = new UpdateEventCommandResponse();
            var eventToUpdate = await _eventRepository.GetByIdAsync(request.EventId);
            if (eventToUpdate == null)
            {
                updateEventCommandResponse.Success = false;
                updateEventCommandResponse.ValidationErrors = new List<string> { "Event not found." };
                return updateEventCommandResponse;
            }

            var validator = new UpdateEventCommandValidator(_eventRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                updateEventCommandResponse.Success = false;
                updateEventCommandResponse.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return updateEventCommandResponse;
            }

            if (updateEventCommandResponse.Success)
            {
                eventToUpdate = _mapper.Map<Event>(request);
                await _eventRepository.UpdateAsync(eventToUpdate);
            }
            updateEventCommandResponse.EventDto = _mapper.Map<UpdateEventDto>(eventToUpdate);
            return updateEventCommandResponse;
        }
    }
}
