using EventFeedbackSystem.Core.Events.Entities;
using EventFeedbackSystem.Shared;

namespace EventFeedbackSystem.Core.Events.Repositories;

public interface IRegisterationRepository : IRepository<Registeration, long>
{
    IQueryable<Event> GetUserRegisteredEvents(long userId);
}
