using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace PCC.Frontend.Lexer
{
    public class PccLexerNotificationHandler : IPccLexerNotificationHandler
    {
        private List<PccLexerNotification> _notifications;

        public PccLexerNotificationHandler()
        {
            _notifications = new List<PccLexerNotification>();
        }

        public void Handle(PccLexerNotification notification)
        {
            _notifications.Add(notification);
        }

        public Task Handle(PccLexerNotification notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);
            return Task.CompletedTask;
        }

        public virtual List<PccLexerNotification> GetNotifications()
        {
            return _notifications.ToList();
        }

        public virtual bool HasNotifications()
        {
            return GetNotifications().Any();
        }

        internal void Dispose()
        {
            _notifications = new List<PccLexerNotification>();
        }
    }
}
