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
    public DbSet<Registeration> Registerations { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply configurations from the assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}