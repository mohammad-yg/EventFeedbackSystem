using EventFeedbackSystem.Core.Events.Entities;
using EventFeedbackSystem.Core.Events.Repositories;

namespace EventFeedbackSystem.EntityFrameworkCore.Events.Repositories;

public class RegisterationRepository : Repository<Registeration, long>, IRegisterationRepository
{
    private readonly AppDbContext _context;
    public RegisterationRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public IQueryable<Event> GetUserRegisterdEvents(long userId)
    {
        return
            _context
            .Registerations
                .Where(e => e.UserId == userId)
                .Include(e => e.Event)
                .Select(e => e.Event);
    }
}
