using EventFeedbackSystem.Core.Auth.Repositories;
using EventFeedbackSystem.Core.Events.Entities;

namespace EventFeedbackSystem.EntityFrameworkCore.Events.Repositories;

public class EventRepository : Repository<Event, long>, IEventsRepository
{
    public EventRepository(AppDbContext context) : base(context)
    {
    }
}
