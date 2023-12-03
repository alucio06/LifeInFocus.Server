using LifeInFocus.Business.Interfaces.Repositories;
using LifeInFocus.Business.Models;
using LifeInFocus.Data.Context;

namespace LifeInFocus.Data.Repositories
{
    public class GoalRepository : BaseRepository<Goal>, IGoalRepository
    {
        public GoalRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
