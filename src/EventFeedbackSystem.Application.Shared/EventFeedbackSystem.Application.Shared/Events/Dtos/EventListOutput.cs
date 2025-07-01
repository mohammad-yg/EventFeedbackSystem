namespace EventFeedbackSystem.Application.Shared.Events.Dtos;

public class EventListOutput
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DateTime { get; set; }
    public string Location { get; set; }
}
