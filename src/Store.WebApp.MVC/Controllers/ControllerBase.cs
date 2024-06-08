using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Core.Communication.Mediator;
using Store.Core.Messages.CommonMessages.Norifications;
using Store.Core.Messages.CommonMessages.Notifications;

namespace Store.WebApp.MVC.Controllers
{
    public abstract class ControllerBase : Controller
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediatorHanlder;

        protected Guid ClienteId = Guid.Parse("b8e59288-46e0-474b-9b01-984e1d4f791b");

        public ControllerBase(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediatrHandler)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediatorHanlder = mediatrHandler;
        }

        protected bool OperacaoValida()
        {
            return !_notifications.TemNotificacao();
        }

        protected IEnumerable<string> ObterMensagensErro()
        {
            return _notifications.ObterNotificacoes().Select(x => x.Value).ToList();
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _mediatorHanlder.PublicarNotificacao(new DomainNotification(codigo, mensagem));
        }
    }
}
