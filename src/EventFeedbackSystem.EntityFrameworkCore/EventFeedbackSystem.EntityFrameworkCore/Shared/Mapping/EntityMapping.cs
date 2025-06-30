using EventFeedbackSystem.Core.Shared;
using Microsoft.EntityFrameworkCore;

namespace EventFeedbackSystem.EntityFrameworkCore.Shared.Mapping;

public class EntityMapping
{
    public static ModelBuilder ApplyMapping(ModelBuilder builder)
    {
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            if (!typeof(Entity<>).IsAssignableFrom(entityType.ClrType.BaseType)) continue;

            builder
                .Entity(entityType.ClrType)
                .HasKey(nameof(Entity<int>.Id));

            //Id
            builder
                .Entity(entityType.ClrType)
                .Property(nameof(Entity<int>.Id))
                .IsRequired();

            //IsDeleted
            builder
                .Entity(entityType.ClrType)
                .Property(nameof(Entity<int>.IsDeleted))
                .HasDefaultValue(false);
        }

        return builder;
    }
}