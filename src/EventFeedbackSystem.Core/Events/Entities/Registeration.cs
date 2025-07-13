using EventFeedbackSystem.Core.Auth.Entities;

namespace EventFeedbackSystem.Core.Events.Entities;

public class Registeration : Entity<long>
{
    public long UserId { get; set; }
    public User User { get; set; }

    public long EventId { get; set; }
    public Event Event { get; set; }
    private Registeration(){}
    public Registeration(long userId, long eventId)
    {
        UserId = userId;
        EventId = eventId;
    }
}
