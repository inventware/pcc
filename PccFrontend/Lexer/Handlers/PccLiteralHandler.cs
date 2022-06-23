using PCC.Core.Handlers;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace PCC.Frontend.Lexer.Handlers
{
    internal class PccLiteralHandler
    {
        private PccDateHandler _dateHandler;
        private PccTimeHandler _timeHandler;
        private int _currentLine;
        private int _currentIndex;


        internal PccLiteralHandler(string lexeme, int currentLine, int currentIndex, int tokenCount,
            string sourceCode, IPccRegExHandler pccRegExHandler)
        {
            _dateHandler = new PccDateHandler(lexeme, currentLine, currentIndex, tokenCount, sourceCode, 
                pccRegExHandler);

            _timeHandler = new PccTimeHandler(lexeme, currentLine, currentIndex, tokenCount, sourceCode, 
                pccRegExHandler);
        }


        internal int CurrentIndex { get => _currentIndex; }

        internal int CurrentLine { get => _currentLine; }


        public Task<IPccToken> Handle(CancellationToken cancellationToken)
        {
            try
            {
                // Chained for valid numeric types.
                _dateHandler
                    .SetNext(_timeHandler);

                var literalToken = _dateHandler.Handle(cancellationToken);
                LoadCurrentData(literalToken.Result);
                return literalToken;
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        private void LoadCurrentData(IPccToken literalToken)
        {
            string tokenNameType = literalToken.Name.ToString().Substring(0, 4);

            switch (tokenNameType)
            {
                case "DATE":
                    _currentLine = _dateHandler.CurrentLine;
                    _currentIndex = _dateHandler.CurrentIndex;
                    break;

                case "TIME":
                    _currentLine = _timeHandler.CurrentLine;
                    _currentIndex = _timeHandler.CurrentIndex;
                    break;

                case "LITE":
                    _currentLine = _timeHandler.CurrentLine;
                    _currentIndex = _timeHandler.CurrentIndex;
                    break;

                default:
                    break;
            }
        }
    }
}
