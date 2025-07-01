using EventFeedbackSystem.Core.Events.Entities;
using EventFeedbackSystem.Core.Events.Repositories;

namespace EventFeedbackSystem.EntityFrameworkCore.Events.Repositories;

public class FeedbackRepository : Repository<Feedback, long>, IFeedbackRepository
{
    public FeedbackRepository(AppDbContext context) : base(context)
    {
    }
}
