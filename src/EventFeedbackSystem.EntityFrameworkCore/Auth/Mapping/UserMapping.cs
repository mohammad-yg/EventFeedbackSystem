using EventFeedbackSystem.Core.Auth.Entities;

namespace EventFeedbackSystem.EntityFrameworkCore.Auth.Mapping;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(e => e.Email).IsUnique();

        //Email
        builder.Property(e => e.Email).IsRequired().HasMaxLength(256);

        //PasswordHash
        builder.Property(e => e.PasswordHash).IsRequired().HasMaxLength(64);
    }
}
