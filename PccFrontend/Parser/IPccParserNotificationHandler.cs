using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace PCC.Frontend.Parser
{
    public interface IPccParserNotificationHandler
    {
        void Handle(PccParserNotification notification);

        Task Handle(PccParserNotification notification, CancellationToken cancellationToken);

        List<PccParserNotification> GetNotifications();

        bool HasNotifications();
    }
}