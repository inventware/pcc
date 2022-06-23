namespace PCC.Frontend.Parser
{
    public interface IPccParser
    {
        void Parser(string sourceCode);

        int TokenCount { get; }

        IPccParserNotificationHandler NotificationsHandler { get; }
    }
}