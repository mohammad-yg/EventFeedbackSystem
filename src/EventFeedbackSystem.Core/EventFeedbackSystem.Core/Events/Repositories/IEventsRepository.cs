using EventFeedbackSystem.Core.Events.Entities;
using EventFeedbackSystem.Shared;

namespace EventFeedbackSystem.Core.Auth.Repositories;

public interface IEventsRepository : IRepository<Event, long>
{
}
