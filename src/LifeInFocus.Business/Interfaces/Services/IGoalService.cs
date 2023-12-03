using LifeInFocus.Business.Models;

namespace LifeInFocus.Business.Interfaces.Services
{
    public interface IGoalService : IDisposable
    {
        Task<Guid?> Add(Goal goal);
        Task Update(Goal goal);
        Task Delete(Guid id);
    }
}
