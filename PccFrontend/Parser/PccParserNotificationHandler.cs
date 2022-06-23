using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace PCC.Frontend.Parser
{
    public class PccParserNotificationHandler : IPccParserNotificationHandler
    {
        private List<PccParserNotification> _notifications;

        public PccParserNotificationHandler()
        {
            _notifications = new List<PccParserNotification>();
        }

        public void Handle(PccParserNotification notification)
        {
            _notifications.Add(notification);
        }

        public Task Handle(PccParserNotification notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);
            return Task.CompletedTask;
        }

        public virtual List<PccParserNotification> GetNotifications()
        {
            return _notifications.ToList();
        }

        public virtual bool HasNotifications()
        {
            return GetNotifications().Any();
        }

        internal void Dispose()
        {
            _notifications = new List<PccParserNotification>();
        }
    }
}
