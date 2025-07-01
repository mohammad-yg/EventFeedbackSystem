using EventFeedbackSystem.Core.Events.Entities;

namespace EventFeedbackSystem.EntityFrameworkCore.Events.Mapping;

public class FeedbackMapping : IEntityTypeConfiguration<Feedback>
{
    public void Configure(EntityTypeBuilder<Feedback> builder)
    {
        //index
        builder.HasIndex(e => new { e.EventId, e.UserId }).IsUnique();

        //user one-to-many
        builder
            .HasOne(e => e.User)
            .WithMany(e => e.Feedbacks)
            .HasForeignKey(e => e.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        //event one-to-many
        builder
            .HasOne(e => e.Event)
            .WithMany(e => e.Feedbacks)
            .HasForeignKey(e => e.EventId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        //rating
        builder
            .Property(e => e.Rating)
            .IsRequired();

        //rating
        builder
            .Property(e => e.Rating)
            .IsRequired();

        //coment
        builder
            .Property(e => e.Comment)
            .IsRequired(false)
            .HasMaxLength(300);
    }
}
