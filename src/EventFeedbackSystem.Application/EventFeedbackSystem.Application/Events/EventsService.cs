using EventFeedbackSystem.Application.Shared.Events;
using EventFeedbackSystem.Application.Shared.Events.Dtos;
using EventFeedbackSystem.Application.Shared.Shared;
using EventFeedbackSystem.Core.Auth.Repositories;
using Mapster;

namespace EventFeedbackSystem.Application.Events;

public class EventsService : IEventsService
{
    private readonly IEventsRepository _eventsRepository;

    public EventsService(IEventsRepository eventsRepository)
    {
        _eventsRepository = eventsRepository;
    }

    public async Task<ServiceResult<EventDetailOutput>> GetEvent(long Id)
    {
        try
        {
            var eventDetail = await _eventsRepository.GetAsync(Id);
            var eventDetailOutput = eventDetail.Adapt<EventDetailOutput>();
            return new ServiceResult<EventDetailOutput>(true, eventDetailOutput);
        }
        catch
        {
            return new ServiceResult<EventDetailOutput>(false, null, "Event not found");
        }
    }

    public Task<ServiceResult<IEnumerable<EventListOutput>>> GetUpcomingList(GetUpcomingListInput input)
    {
        try
        {
            var events = _eventsRepository
                .GetAll()
                .Where(e => e.DateTime > DateTime.UtcNow)
                .ProjectToType<EventListOutput>()
                .ToList();

            return Task.FromResult(new ServiceResult<IEnumerable<EventListOutput>>(true, events));
        }
        catch
        {
            return Task.FromResult(new ServiceResult<IEnumerable<EventListOutput>>(false, null, "Error retrieving events"));
        }
    }
}
