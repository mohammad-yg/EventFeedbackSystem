using EventFeedbackSystem.Core.Events.Entities;

namespace EventFeedbackSystem.EntityFrameworkCore.Events.Mapping;

public class RegisterationMapping : IEntityTypeConfiguration<Registeration>
{
    public void Configure(EntityTypeBuilder<Registeration> builder)
    {
        //Prevent duplicate records
        builder.HasIndex(e => new { e.UserId, e.EventId }).IsUnique();

        //register-user one-to-many
        builder
            .HasOne(e => e.User)
            .WithMany(e => e.Registerations)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        //register-event one-to-many
        builder
            .HasOne(e => e.Event)
            .WithMany(e => e.Registerations)
            .HasForeignKey(e => e.EventId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
