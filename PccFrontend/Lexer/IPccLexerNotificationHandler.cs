using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PCC.Frontend.Lexer
{
    public interface IPccLexerNotificationHandler
    {
        void Handle(PccLexerNotification notification);

        Task Handle(PccLexerNotification notification, CancellationToken cancellationToken);

        List<PccLexerNotification> GetNotifications();

        bool HasNotifications();
    }
}