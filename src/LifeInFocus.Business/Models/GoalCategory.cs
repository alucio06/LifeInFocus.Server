namespace LifeInFocus.Business.Models
{
    public class GoalCategory : Entity
    {
        public string Name { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }
        public bool IsDeleted { get; set; }

        // EF Relations
        public IEnumerable<Goal>? Goals { get; set; }
    }
}
