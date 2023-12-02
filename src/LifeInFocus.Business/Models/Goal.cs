namespace LifeInFocus.Business.Models
{
    public class Goal : Entity
    {
        public string Nome { get; set; } = string.Empty;
        public DateTime? Prazo { get; set; }
        public string? Motivacao { get; set; }
        public string? Recompensa { get; set; }
        public GoalCategory Categoria { get; set; } = new GoalCategory();
        public int Prioridade { get; set; }
    }
}
