using EventFeedbackSystem.Core.Events.Entities;

namespace EventFeedbackSystem.EntityFrameworkCore.Events.Mapping;

public class EventMapping : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        //Title
        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(50);

        //Description
        builder.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(300);

        //DateTime
        builder.Property(e => e.DateTime)
            .IsRequired();

        //Location
        builder.Property(e => e.Location)
            .IsRequired()
            .HasMaxLength(30);
    }
}
