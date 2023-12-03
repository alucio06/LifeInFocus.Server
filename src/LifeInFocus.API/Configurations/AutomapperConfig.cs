using AutoMapper;
using LifeInFocus.API.ViewModels;
using LifeInFocus.Business.Models;

namespace LifeInFocus.API.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Goal, GoalListViewModel>().ReverseMap();
            CreateMap<Goal, GoalDetailsViewModel>().ReverseMap();
            CreateMap<GoalAddViewModel, Goal>();
            CreateMap<GoalEditViewModel, Goal>();

            CreateMap<GoalCategory, GoalCategoryViewModel>().ReverseMap();
        }
    }
}
