using PCC.Core.Handlers;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace PCC.Frontend.Lexer.Handlers
{
    internal class PccTimeHandler : PccCharactersHandler
    {
        private const string PATTERN_TO_MATCH = @"^((-?[0-9]+|[0-9]*))$";

        internal PccTimeHandler(string lexeme, int currentLine, int currentIndex, int tokenCount,
            string sourceCode, IPccRegExHandler pccRegExHandler)
        : base(lexeme, currentLine, currentIndex, tokenCount, sourceCode, pccRegExHandler)
        {
        }


        public override Task<IPccToken> Handle(CancellationToken cancellationToken)
        {
            try
            {
                return TimeFormatIsDDMMYYYY_HHMMSS(cancellationToken);
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        protected Task<IPccToken> TimeFormatIsDDMMYYYY_HHMMSS(CancellationToken cancellationToken)
        {
            const string PATTERN_TO_MATCH = @"^(0\d|1\d|2[0|1|2|3]):(0\d|1\d|2\d|3\d|4\d|5\d):(0\d|1\d|2\d|3\d|4\d|5\d)$";

            string timeLexeme = _pccRegExHandler.ValidateString(_lexeme, PATTERN_TO_MATCH, cancellationToken).Result;
            if (!string.IsNullOrEmpty(timeLexeme))
            {
                return Task.FromResult<IPccToken>(
                    new PccToken(_tokenCount, ETokenName.TIME_HHMMSS, timeLexeme, _currentLine));
            }
            return TimeFormatIsHHMMSS_MMM(cancellationToken);
        }


        protected Task<IPccToken> TimeFormatIsHHMMSS_MMM(CancellationToken cancellationToken)
        {
            const string PATTERN_TO_MATCH = @"^(0\d|1\d|2[0|1|2|3]):(0\d|1\d|2\d|3\d|4\d|5\d):(0\d|1\d|2\d|3\d|4\d|5\d)[ ]+\d{3}$";

            string timeLexeme = _pccRegExHandler.ValidateString(_lexeme, PATTERN_TO_MATCH, cancellationToken).Result;
            if (!string.IsNullOrEmpty(timeLexeme))
            {
                return Task.FromResult<IPccToken>(
                    new PccToken(_tokenCount, ETokenName.TIME_HHMMSS_MMM, timeLexeme, _currentLine));
            }
            return TimeFormatIsHHMMSS_AMPM(cancellationToken);
        }


        protected Task<IPccToken> TimeFormatIsHHMMSS_AMPM(CancellationToken cancellationToken)
        {
            const string PATTERN_TO_MATCH = @"^(0\d|1\d|2[0|1|2|3]):(0\d|1\d|2\d|3\d|4\d|5\d):(0\d|1\d|2\d|3\d|4\d|5\d)[ ]+(AM|am|PM|pm)$";

            string timeLexeme = _pccRegExHandler.ValidateString(_lexeme, PATTERN_TO_MATCH, cancellationToken).Result;
            if (!string.IsNullOrEmpty(timeLexeme))
            {
                return Task.FromResult<IPccToken>(
                    new PccToken(_tokenCount, ETokenName.TIME_HHMMSS_AMPM, timeLexeme, _currentLine));
            }
            return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.LITERAL, _lexeme, _currentLine));
        }
    }
}
