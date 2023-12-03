namespace LifeInFocus.API.ViewModels
{
    public class GoalListViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime? Deadline { get; set; }
        public Guid CategoryId { get; set; }
        public string? Motivation { get; set; }
        public string? Reward { get; set; }
        public int Priority { get; set; }
        public DateTime RegistrationDate { get; set; }
        public GoalCategoryViewModel Category { get; set; } = new GoalCategoryViewModel();
    }

    public class GoalDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime? Deadline { get; set; }
        public Guid CategoryId { get; set; }
        public string? Motivation { get; set; }
        public string? Reward { get; set; }
        public int Priority { get; set; }
        public DateTime RegistrationDate { get; set; }
        public GoalCategoryViewModel Category { get; set; } = new GoalCategoryViewModel();
    }

    public class GoalAddViewModel
    {
        public string Name { get; set; } = string.Empty;
        public DateTime? Deadline { get; set; }
        public Guid CategoryId { get; set; }
        public string? Motivation { get; set; }
        public string? Reward { get; set; }
        public int Priority { get; set; }
    }

    public class GoalEditViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime? Deadline { get; set; }
        public Guid CategoryId { get; set; }
        public string? Motivation { get; set; }
        public string? Reward { get; set; }
        public int Priority { get; set; }
    }
}
