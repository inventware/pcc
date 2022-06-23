using PCC.Core.Handlers;
using PCC.Frontend.Lexer;
using System.Threading;
using System.Threading.Tasks;


namespace PCC.Frontend
{
    public class PccBasicCompiler
    {
        private PccRegExHandler _pccRegExHandler;
        private PccLexerNotificationHandler _notificationsHandler;
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        private PccLexer _pccLexer;
        private PccTableOfTokens _pccTableOfTokens;
        private int _tokenCount;


        public PccBasicCompiler(string sourceCode)
        {
            _pccRegExHandler = new PccRegExHandler();
            _notificationsHandler = new PccLexerNotificationHandler();
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            _pccTableOfTokens = new PccTableOfTokens();
            _tokenCount = 0;
        }

        public Task Compile()
        {
            var token = _pccLexer.GetNextToken(_tokenCount).Result;
            if (!_cancellationToken.IsCancellationRequested)
            {
                _tokenCount++;
                _pccTableOfTokens.Insert(token);
            }

            return null;
        }
    }
}
