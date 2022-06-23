using PCC.Core.Handlers;
using System.Threading;
using System.Threading.Tasks;


namespace PCC.Frontend.Lexer.Handlers
{
    internal class PccCommentedTextHandler : PccCharactersHandler
    {
        internal PccCommentedTextHandler(string lexeme, int currentLine, int currentIndex, int tokenCount,
            string sourceCode, IPccRegExHandler pccRegExHandler)
        : base(lexeme, currentLine, currentIndex, tokenCount, sourceCode, pccRegExHandler)
        {
        }


        public override Task<IPccToken> Handle(CancellationToken cancellationToken)
        {
            if (isPeekASingleQuote())
            {
                ScanAllCharactersToTheRightOfSingleQuote();
                return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.COMMENTED_TEXT, 
                    _lexeme, _currentLine, false));
            }
            return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.UNDEFINED, _lexeme, _currentLine));
        }
    }
}
