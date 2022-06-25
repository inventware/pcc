using PCC.Frontend.Lexer;
using System;


namespace PCC.Frontend.Parser
{
    public class PccFunctionParser : PccMethodParser, IPccParser
    {
        public void Parser(string sourceCode, int? tokenCount, IPccToken lookAhead, IPccLexer pccLexer, 
            IPccParserNotificationHandler NotificationsHandler)
        {
            _tokenCount = tokenCount.GetValueOrDefault();
            _lookAhead = lookAhead;
            _pccLexer = pccLexer;
            _notificationsHandler = NotificationsHandler;

            Match(ETokenName.FUNCTION);
            Match(ETokenName.ID);
            Match(ETokenName.OPEN_BRACKET);
            ParametersStatement();
            // Code Block
            Match(ETokenName.END);
            Match(ETokenName.FUNCTION);
            // Return of Function
        }
    }
}
