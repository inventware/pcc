using PCC.Core.Handlers;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace PCC.Frontend.Lexer.Handlers
{
    internal class PccFloatingNumberHandler : PccCharactersHandler
    {
        // This pattern allows decimal numbers in this format: '.1', '-.1'.
        private const string PATTERN_TO_MATCH = @"^((-?[0-9]*)?(\.[0-9]+)?)$";

        internal PccFloatingNumberHandler(string lexeme, int currentLine, int currentIndex, int tokenCount,
            string sourceCode, IPccRegExHandler pccRegExHandler) 
        : base(lexeme, currentLine, currentIndex, tokenCount, sourceCode, pccRegExHandler)
        {
        }

        public override Task<IPccToken> Handle(CancellationToken cancellationToken)
        {
            try
            {
                string numericLexeme = _pccRegExHandler.ValidateString(_lexeme, PATTERN_TO_MATCH, cancellationToken).Result;
                if (!string.IsNullOrEmpty(numericLexeme))
                {
                    return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.NUM_FLOAT, numericLexeme,
                        _currentLine));
                }
                return base.Handle(cancellationToken);
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
