using EventFeedbackSystem.Application.Shared.Auth.Dtos;
using EventFeedbackSystem.Application.Shared.Events;
using EventFeedbackSystem.Application.Shared.Shared;
using EventFeedbackSystem.Core.Events.Entities;
using EventFeedbackSystem.Core.Events.Repositories;
using EventFeedbackSystem.Core.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace EventFeedbackSystem.Application.Events;

public class FeedbackService : IFeedbackService
{
    private readonly IFeedbackRepository _feedbackRepository;
    private readonly IRegisterationRepository _registerationRepository;

    public FeedbackService(IFeedbackRepository feedbackRepository, IRegisterationRepository registerationRepository)
    {
        _feedbackRepository = feedbackRepository;
        _registerationRepository = registerationRepository;
    }

    public async Task<ServiceResult> AddFeedbackAsync(long userId, AddFeedbackInput input)
    {
        var feedback = new Feedback(userId, input.EventId, input.Rating, input.Comment);
        var _event = await _registerationRepository
            .GetAll()
            .Where(r => r.UserId == userId && r.EventId == input.EventId)
            .Include(e => e.Event)
            .Select(r => r.Event)
            .FirstOrDefaultAsync();

        //continue if the user is registered for the event
        if (_event == null)
            return new ServiceResult(false, "User is not registered for this event.");

        //continue if the event is finished
        if (_event.DateTime > DateTime.UtcNow)
            return new ServiceResult(false, "EventIsNotFinished", "Event is not finished yet.");

        try
        {
            await _feedbackRepository.AddAsync(feedback);
            return new ServiceResult(true, "Feedback added successfully.");
        }
        catch (InfrastructureException ex)
        {
            switch (ex.Message)
            {
                case InfrastructureException.Messages.InvalidForeignKey:
                    return new ServiceResult(false, "event not found");
                case InfrastructureException.Messages.DuplicateRow:
                    return new ServiceResult(false, "feedback already is exist");
                default:
                    return new ServiceResult(false, "An error occurred while adding feedback.");
            }
        }
    }
}
