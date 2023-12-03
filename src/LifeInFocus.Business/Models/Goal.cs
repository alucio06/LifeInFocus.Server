namespace LifeInFocus.Business.Models
{
    public class Goal : Entity
    {
        public string Name { get; set; } = string.Empty;
        public DateTime? Deadline { get; set; }
        public int CategoryId { get; set; }
        public string? Motivation { get; set; }
        public string? Reward { get; set; }
        public int Priority { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsDeleted { get; set; }

        // EF Relations
        public GoalCategory Category { get; set; } = new GoalCategory();
    }
}
