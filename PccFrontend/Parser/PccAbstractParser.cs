using PCC.Core.Handlers;
using PCC.Frontend.Lexer;
using System.Threading;

namespace PCC.Frontend.Parser
{
    public abstract class PccAbstractParser
    {
        protected IPccRegExHandler _pccRegExHandler;
        protected IPccParserNotificationHandler _notificationsHandler;
        protected IPccLexer _pccLexer;
        protected IPccToken _lookAhead;
        protected int _tokenCount;
        protected CancellationToken _cancellationToken;


        internal PccAbstractParser(){}

        internal PccAbstractParser(IPccRegExHandler pccRegExHandler, IPccParserNotificationHandler
            notificationsHandler, CancellationTokenSource cancellationTokenSource)
        {
            _pccRegExHandler = pccRegExHandler;
            _notificationsHandler = notificationsHandler;
            _cancellationToken = cancellationTokenSource.Token;
        }

        public IPccToken LookAhead
        {
            get => _lookAhead;
            protected set => _lookAhead = value;
        }

        public int TokenCount 
        { 
            get => _tokenCount; 
            protected set => _tokenCount = value; 
        }

        public IPccLexer PccLexer
        {
            get => _pccLexer;
            protected set => _pccLexer = value;
        }

        public IPccParserNotificationHandler NotificationsHandler
        {
            get => _notificationsHandler;
            protected set => _notificationsHandler = value;
        }


        protected void IncrTokenCountIfIsNotEndOfCode()
        {
            if (!_lookAhead.Name.Equals(ETokenName.END_OF_CODE)){
                _tokenCount++;
            }
        }

        protected void Match(ETokenName tokenName)
        {
            if (_lookAhead.Name == tokenName)
            {
                _tokenCount += 1;
                _lookAhead = _pccLexer.GetNextToken(_tokenCount).Result;
            }
            else
            {
                _notificationsHandler.Handle(new PccParserNotification("PAR_" + _tokenCount.ToString(),
                    "SYNTAX ERROR", _lookAhead.Lexeme.Line));
            }
        }
    }
}
