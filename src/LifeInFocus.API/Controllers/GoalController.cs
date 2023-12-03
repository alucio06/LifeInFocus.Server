using AutoMapper;
using LifeInFocus.API.ViewModels;
using LifeInFocus.Business.Interfaces;
using LifeInFocus.Business.Interfaces.Repositories;
using LifeInFocus.Business.Interfaces.Services;
using LifeInFocus.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LifeInFocus.API.Controllers
{
    [Route("api/goal")]
    [ApiController]
    public class GoalController : MainController
    {
        readonly IGoalRepository _goalRepository;
        readonly IGoalService _goalService;
        readonly IMapper _mapper;

        public GoalController(INotifier notifier, IGoalRepository goalRepository, IGoalService goalService, IMapper mapper) : base(notifier)
        {
            _goalRepository = goalRepository;
            _goalService = goalService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<GoalListViewModel>> GetAll()
        {
            var result = _mapper.Map<IEnumerable<GoalListViewModel>>(await _goalRepository.GetAll());
            return result;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GoalDetailsViewModel>> GetById(Guid id)
        {
            var goalViewModel = _mapper.Map<GoalDetailsViewModel>(await _goalRepository.GetById(id));

            if (goalViewModel is null) return NotFound();

            return goalViewModel;
        }

        [HttpPost]
        public async Task<ActionResult<GoalAddViewModel>> Add(GoalAddViewModel goalAddViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _goalService.Add(_mapper.Map<Goal>(goalAddViewModel));
            if (result is null) return CustomResponse();

            return CustomResponse(HttpStatusCode.Created, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<GoalEditViewModel>> Update(Guid id, GoalEditViewModel goalUpdateViewModel)
        {
            if (ModelState.IsValid) return CustomResponse(ModelState);

            if (id != goalUpdateViewModel.Id)
            {
                NotifyError("Os ids informados não são iguais!");
                return CustomResponse(HttpStatusCode.NoContent);
            }

            await _goalService.Update(_mapper.Map<Goal>(goalUpdateViewModel));

            return CustomResponse();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var goal = await _goalRepository.GetById(id);
            
            if (goal == null) return NotFound();

            await _goalService.Delete(id);

            return CustomResponse(HttpStatusCode.NoContent);
        }

    }
}
