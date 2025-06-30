namespace EventFeedbackSystem.Core.Events.Entities;

public class Event : Entity<long>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DateTime { get; set; }
    public string Location { get; set; }

    public IEnumerable<Registeration> Registerations { get; set; }

    public Event(string title, string description, DateTime dateTime, string location)
    {
        Title = title;
        Description = description;
        DateTime = dateTime;
        Location = location;
    }

    //for add migration
    public Event()
    {
    }
}
