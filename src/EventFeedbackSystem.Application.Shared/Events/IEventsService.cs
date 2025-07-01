using EventFeedbackSystem.Application.Shared.Events.Dtos;

namespace EventFeedbackSystem.Application.Shared.Events;

public interface IEventsService
{
    Task<ServiceResult<EventDetailOutput?>> GetEvent(long Id);
    Task<ServiceResult<IEnumerable<EventListOutput>>> GetUpcomingList(GetUpcomingListInput input);
    Task<ServiceResult> Register(long userId, long evnetId);
    Task<ServiceResult<IEnumerable<EventListOutput>>> GetUserRegisterationsList(long userId);
}
