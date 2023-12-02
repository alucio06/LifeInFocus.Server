using FluentValidation;
using FluentValidation.Results;
using LifeInFocus.Business.Interfaces;
using LifeInFocus.Business.Models;
using LifeInFocus.Business.Notificacoes;

namespace LifeInFocus.Business.Services
{
    public class BaseService
    {
        public readonly INotifier _notifier;

        protected BaseService(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected bool ExecutarValidacao<TV, TE>(TV validation, TE entity)
            where TV : AbstractValidator<TE>
            where TE : Entity
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            Notify(validator);

            return false;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected void Notify(string message)
        {
            _notifier.Handle(new Notification(message));
        }
    }
}
