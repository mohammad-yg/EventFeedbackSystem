using EventFeedbackSystem.Core.Auth.Entities;
using EventFeedbackSystem.Core.Events.Entities;

namespace EventFeedbackSystem.EntityFrameworkCore.Shared;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    //Auth
    public DbSet<User> Users { get; set; }

    //Event
    public DbSet<Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply configurations from the assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        modelBuilder.Entity<Event>().HasData(new Event[]
        {
            new Event
            {
                Id = 1,
                Title = "Event 1",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                DateTime = DateTime.UtcNow - TimeSpan.FromDays(1),
                Location = "Tehran"
            },
            new Event
            {
                Id = 2,
                Title = "Event 2",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                DateTime = DateTime.UtcNow + TimeSpan.FromDays(1),
                Location = "Tehran"
            },
            new Event
            {
                Id = 3,
                Title = "Event 3",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                DateTime = DateTime.UtcNow + TimeSpan.FromDays(2),
                Location = "Tehran"
            },
            new Event
            {
                Id = 4,
                Title = "Event 4",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                DateTime = DateTime.UtcNow + TimeSpan.FromDays(3),
                Location = "Tehran"
            },
            new Event
            {
                Id = 5,
                Title = "Event 5",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                DateTime = DateTime.UtcNow + TimeSpan.FromDays(4),
                Location = "Tehran"
            },
        });

        base.OnModelCreating(modelBuilder);
    }
}