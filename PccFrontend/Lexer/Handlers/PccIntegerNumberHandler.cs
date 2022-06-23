using PCC.Core.Handlers;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace PCC.Frontend.Lexer.Handlers
{
    internal class PccIntegerNumberHandler : PccCharactersHandler
    {
        private const string PATTERN_TO_MATCH = @"^((-?[0-9]+|[0-9]*))$";

        internal PccIntegerNumberHandler(string lexeme, int currentLine, int currentIndex, int tokenCount,
            string sourceCode, IPccRegExHandler pccRegExHandler)
        : base(lexeme, currentLine, currentIndex, tokenCount, sourceCode, pccRegExHandler)
        {
        }


        public override Task<IPccToken> Handle(CancellationToken cancellationToken)
        {
            try
            {
                if (isPeekADigit() || isPeekADot() || isPeekASubtractionOperator())
                {
                    ScanNumericCharacters();
                    return IsAnIntegerNumber(cancellationToken);
                }
                return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.UNDEFINED, _lexeme, _currentLine));
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        public Task<IPccToken> IsAnIntegerNumber(CancellationToken cancellationToken)
        {
            string numericLexeme = _pccRegExHandler.ValidateString(_lexeme, PATTERN_TO_MATCH, cancellationToken).Result;
            if (!string.IsNullOrEmpty(numericLexeme))
            {
                return Task.FromResult<IPccToken>(
                    new PccToken(_tokenCount, ETokenName.NUM_INT, numericLexeme, _currentLine));
            }
            return base.Handle(cancellationToken);
        }
    }
}
