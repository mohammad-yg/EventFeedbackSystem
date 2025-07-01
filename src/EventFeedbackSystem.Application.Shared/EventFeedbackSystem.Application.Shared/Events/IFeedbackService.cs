using EventFeedbackSystem.Application.Shared.Auth.Dtos;

namespace EventFeedbackSystem.Application.Shared.Events;

public interface IFeedbackService
{
    /// <summary>
    /// Adds feedback for an event.
    /// </summary>
    /// <param name="userId">The ID of the user providing feedback.</param>
    /// <param name="eventId">The ID of the event for which feedback is being provided.</param>
    /// <param name="input">The feedback dto to be added.</param>
    /// <returns>A ServiceResult task representing the asynchronous operation.</returns>
    Task<ServiceResult> AddFeedbackAsync(long userId, long eventId, AddFeedbackInput input);
}