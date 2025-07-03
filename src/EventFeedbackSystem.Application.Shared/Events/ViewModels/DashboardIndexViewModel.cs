using EventFeedbackSystem.Application.Shared.Events.Dtos;

namespace EventFeedbackSystem.Application.Shared.Events.ViewModels;

public class DashboardIndexViewModel
{
    public IEnumerable<EventListOutput> RegisteredEvents { get; set; }
}
