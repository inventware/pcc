using PCC.Core.Handlers;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace PCC.Frontend.Lexer.Handlers
{
    internal class PccNumericHandler
    {
        private PccIntegerNumberHandler _integerNumberHandler;
        private PccFloatingNumberHandler _floatingNumberHandler;
        private PccScientificNotationNumberHandler _scientificNotNumberHandler;
        private int _currentLine;
        private int _currentIndex;


        internal PccNumericHandler(string lexeme, int currentLine, int currentIndex, int tokenCount, string sourceCode, 
            IPccRegExHandler pccRegExHandler)
        {
            _integerNumberHandler = new PccIntegerNumberHandler(lexeme, currentLine, currentIndex, tokenCount, 
                sourceCode, pccRegExHandler);

            _floatingNumberHandler = new PccFloatingNumberHandler(lexeme, currentLine, currentIndex, tokenCount, 
                sourceCode, pccRegExHandler);

            _scientificNotNumberHandler = new PccScientificNotationNumberHandler(lexeme, currentLine, currentIndex, 
                tokenCount, sourceCode, pccRegExHandler);
        }

        internal int CurrentIndex { get => _currentIndex; }

        internal int CurrentLine { get => _currentLine; }


        public Task<IPccToken> Handle(CancellationToken cancellationToken)
        {
            try
            {
                // Chained for valid numeric types.
                _integerNumberHandler
                    .SetNext(_floatingNumberHandler)
                    .SetNext(_scientificNotNumberHandler);

                var numericToken = _integerNumberHandler.Handle(cancellationToken);
                LoadCurrentData(numericToken.Result);
                return numericToken;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        private void LoadCurrentData(IPccToken numericToken)
        {
            switch (numericToken.Name)
            {
                case ETokenName.NUM_INT:
                    _currentLine = _integerNumberHandler.CurrentLine;
                    _currentIndex = _integerNumberHandler.CurrentIndex;
                    break;

                case ETokenName.NUM_FLOAT:
                    _currentLine = _floatingNumberHandler.CurrentLine;
                    _currentIndex = _floatingNumberHandler.CurrentIndex;
                    break;

                case ETokenName.NUM_SCIENT_NOT:
                    _currentLine = _scientificNotNumberHandler.CurrentLine;
                    _currentIndex = _scientificNotNumberHandler.CurrentIndex;
                    break;

                default:
                    break;
            }
        }
    }
}
