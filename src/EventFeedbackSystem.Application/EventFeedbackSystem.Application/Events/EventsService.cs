using EventFeedbackSystem.Application.Shared.Events;
using EventFeedbackSystem.Application.Shared.Events.Dtos;
using EventFeedbackSystem.Application.Shared.Shared;
using EventFeedbackSystem.Core.Auth.Repositories;
using EventFeedbackSystem.Core.Events.Entities;
using EventFeedbackSystem.Core.Events.Repositories;
using EventFeedbackSystem.Core.Shared.Exceptions;
using Mapster;

namespace EventFeedbackSystem.Application.Events;

public class EventsService : IEventsService
{
    private readonly IEventsRepository _eventsRepository;
    private readonly IRegisterationRepository _registerationRepository;

    public EventsService(IEventsRepository eventsRepository, IRegisterationRepository registerationRepository)
    {
        _eventsRepository = eventsRepository;
        _registerationRepository = registerationRepository;
    }

    public async Task<ServiceResult<EventDetailOutput>> GetEvent(long Id)
    {
        var eventDetail = await _eventsRepository.GetAsync(Id);

        if (eventDetail is null)
            return new ServiceResult<EventDetailOutput>(false, null, "NotFound");

        return new ServiceResult<EventDetailOutput>(true, eventDetail.Adapt<EventDetailOutput>());
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

    public async Task<ServiceResult> Register(long userId, long evnetId)
    {
        try
        {
            await _registerationRepository.AddAsync(new Registeration()
            {
                UserId = userId,
                EventId = evnetId
            });
            return new ServiceResult(true);
        }
        catch (InfrastructureException ex)
        {
            switch (ex.Message)
            {
                case InfrastructureException.Messages.InvalidForeignKey:
                    return new ServiceResult(false, "event not found");

                case InfrastructureException.Messages.DuplicateRow:
                    return new ServiceResult(false, "duplicate registeration");
            }

            return new ServiceResult(false);
        }
    }
}
