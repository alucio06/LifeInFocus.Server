using LifeInFocus.Business.Interfaces;
using LifeInFocus.Business.Interfaces.Repositories;
using LifeInFocus.Business.Interfaces.Services;

namespace LifeInFocus.Business.Services
{
    public class GoalService : BaseService, IGoalService
    {
        private readonly IGoalRepository _goalRepository;

        public GoalService(IGoalRepository goalRepository, INotifier notificador) : base(notificador)
        {
            _goalRepository = goalRepository;
        }

        public void Dispose()
        {
            _goalRepository.Dispose();
        }
    }
}
