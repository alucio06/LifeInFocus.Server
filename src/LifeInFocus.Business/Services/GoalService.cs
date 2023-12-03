using LifeInFocus.Business.Interfaces;
using LifeInFocus.Business.Interfaces.Repositories;
using LifeInFocus.Business.Interfaces.Services;
using LifeInFocus.Business.Models;
using LifeInFocus.Business.Models.Validations;

namespace LifeInFocus.Business.Services
{
    public class GoalService : BaseService, IGoalService
    {
        private readonly IGoalRepository _goalRepository;

        public GoalService(IGoalRepository goalRepository, INotifier notificador) : base(notificador)
        {
            _goalRepository = goalRepository;
        }

        public async Task<Guid?> Add(Goal goal)
        {
            if (!ExecutarValidacao(new GoalValidation(), goal)) return null;

            goal.RegistrationDate = DateTime.Now;
            goal.IsDeleted = false;

            await _goalRepository.Add(goal);

            return goal.Id;
        }

        public async Task Update(Goal goal)
        {
            if (!ExecutarValidacao(new GoalValidation(), goal)) return;

            if (!(await _goalRepository.Search(g => g.Id == goal.Id)).Any())
            {
                Notify("Meta não encontrada");
                return;
            }

            await _goalRepository.Update(goal);
        }

        public async Task Delete(Guid id)
        {
            if (!(await _goalRepository.Search(g => g.Id == id)).Any())
            {
                Notify("Meta não encontrada");
                return;
            }

            await _goalRepository.Remove(id);
        }

        public void Dispose()
        {
            _goalRepository.Dispose();
        }

    }
}
