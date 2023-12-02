using FluentValidation;

namespace LifeInFocus.Business.Models.Validations
{
    public class GoalValidation : AbstractValidator<Goal>
    {
        public GoalValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome precisa ser preenchido")
                .Length(3, 200).WithMessage("O nome da meta deve conter entre {MinLength} e {MaxLenght} caracteres");
            RuleFor(c => c.Categoria)
                .NotNull().WithMessage("É necessário adicionar uma categoria para a meta");
            RuleFor(c => c.Prioridade)
                .NotNull().WithMessage("É necessário adicionar uma prioridade para a meta");
        }
    }
}
