using EventFeedbackSystem.Core.Auth.Entities;
using EventFeedbackSystem.Core.Shared.Exceptions;
using System.Reflection.Metadata.Ecma335;

namespace EventFeedbackSystem.Core.Events.Entities;

public class Feedback : Entity<long>
{
    public long UserId { get; set; }
    public User User { get; set; }

    public long EventId { get; set; }
    public Event Event { get; set; }

    public int Rating { get; set; }
    public string Comment { get; set; }


    private Feedback(){}

    public Feedback(long userId, long eventId, int rating, string comment)
    {
        UserId = userId;
        EventId = eventId;

        if (rating < 1 || rating > 5)
            throw new DomainException("invalid rating value");

        Rating = rating;
        Comment = comment;
    }
}
