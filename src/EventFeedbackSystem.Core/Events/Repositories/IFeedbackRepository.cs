using EventFeedbackSystem.Core.Events.Entities;
using EventFeedbackSystem.Shared;

namespace EventFeedbackSystem.Core.Events.Repositories;

public interface IFeedbackRepository : IRepository<Feedback, long>
{

}
