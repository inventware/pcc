using PCC.Frontend.Lexer;


namespace PCC.Frontend.Parser
{
    public class PccSubroutineParser : PccMethodParser, IPccParser
    {
        public void Parser(string sourceCode, int? tokenCount, IPccToken lookAhead, IPccLexer pccLexer, 
            IPccParserNotificationHandler NotificationsHandler)
        {
            _tokenCount = tokenCount.GetValueOrDefault();
            _lookAhead = lookAhead;
            _pccLexer = pccLexer;
            _notificationsHandler = NotificationsHandler;

            Match(ETokenName.SUB);
            Match(ETokenName.ID);
            Match(ETokenName.OPEN_BRACKET);
            ParametersStatement();
            // Code Block
            Match(ETokenName.END);
            Match(ETokenName.SUB);
        }
    }
}
