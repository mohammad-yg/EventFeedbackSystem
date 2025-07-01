using EventFeedbackSystem.Core.Events.Entities;
using EventFeedbackSystem.Core.Events.Repositories;

namespace EventFeedbackSystem.EntityFrameworkCore.Events.Repositories;

public class RegisterationRepository : Repository<Registeration, long>, IRegisterationRepository
{
    public RegisterationRepository(AppDbContext context) : base(context)
    {
    }
}
