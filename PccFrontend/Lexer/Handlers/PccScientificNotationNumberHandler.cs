using PCC.Core.Handlers;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;


namespace PCC.Frontend.Lexer.Handlers
{
    internal class PccScientificNotationNumberHandler : PccCharactersHandler
    {
        private const string PATTERN_TO_MATCH = @"^((-?[0-9]*)?(\.[0-9]+)?((e|e\+|e-|E|E\+|E-)[0-9]+)?)$";

        internal PccScientificNotationNumberHandler(string lexeme, int currentLine, int currentIndex, 
            int tokenCount, string sourceCode, IPccRegExHandler pccRegExHandler) 
        : base(lexeme, currentLine, currentIndex, tokenCount, sourceCode, pccRegExHandler)
        {
        }

        public override Task<IPccToken> Handle(CancellationToken cancellationToken)
        {
            try
            {
                string numericLexeme = _pccRegExHandler.ValidateString(_lexeme, PATTERN_TO_MATCH, cancellationToken).Result;
                if (!string.IsNullOrEmpty(numericLexeme) && IsAScientificNotationNumber(numericLexeme))
                {
                    return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.NUM_SCIENT_NOT, numericLexeme,
                        _currentLine));
                }
                return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.UNDEFINED, _lexeme, _currentLine));
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        private bool IsAScientificNotationNumber(string lexeme)
        {
            try
            {
                double variableValue = 0;
                if (double.TryParse(lexeme, NumberStyles.Any, CultureInfo.InvariantCulture, out variableValue)){
                    return true; 
                }
                return false;
            }
            catch (OverflowException errOverFlow)
            {
                throw errOverFlow;
            }
            catch (Exception err)
            {
                throw new OverflowException(string.Format("It occurred an error in the validation of {0} for the " +
                    "value({1}) ({2}).", ETokenName.SINGLE, lexeme, err.Message));
            }
        }
    }
}
