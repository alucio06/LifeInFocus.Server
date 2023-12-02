using FluentValidation;

namespace LifeInFocus.Business.Models.Validations
{
    public class GoalCategoryValidation : AbstractValidator<GoalCategory>
    {
        public GoalCategoryValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome da categoria precisa ser preenchido")
                .Length(3, 200).WithMessage("O nome da categoria deve conter entre {MinLength} e {MaxLenght} caracteres");
        }
    }
}
