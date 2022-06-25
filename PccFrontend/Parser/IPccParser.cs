using PCC.Frontend.Lexer;

namespace PCC.Frontend.Parser
{
    public interface IPccParser
    {
        int TokenCount { get; }

        IPccLexer PccLexer { get; }

        IPccToken LookAhead { get; }

        IPccParserNotificationHandler NotificationsHandler { get; }

        void Parser(string sourceCode, int? tokenCount, IPccToken lookAhead, IPccLexer pccLexer, 
            IPccParserNotificationHandler NotificationsHandler);
    }
}