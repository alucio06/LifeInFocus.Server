using LifeInFocus.Business.Interfaces;
using LifeInFocus.Business.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace LifeInFocus.API.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        readonly INotifier _notifier;

        public MainController(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected bool OperationIsValid()
        {
            return !_notifier.HasNotification();
        }

        protected ActionResult CustomResponse(HttpStatusCode statusCode = HttpStatusCode.OK, object? result = null)
        {
            if (OperationIsValid())
            {
                return new ObjectResult(result)
                {
                    StatusCode = Convert.ToInt32(statusCode)
                };
            }

            return BadRequest(new
            {
                errors = _notifier.GetNotifications().Select(n => n.Message)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifyModelInvalidError(modelState);

            return CustomResponse();
        }

        protected void NotifyModelInvalidError(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError(erroMsg);
            }
        }

        protected void NotifyError(string message)
        {
            _notifier.Handle(new Notification(message));
        }
    }
}
