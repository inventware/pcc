using PCC.Core.Handlers;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace PCC.Frontend.Lexer.Handlers
{
    internal class PccDateHandler : PccCharactersHandler
    {
        private const string PATTERN_TO_MATCH = @"^((-?[0-9]+|[0-9]*))$";

        internal PccDateHandler(string lexeme, int currentLine, int currentIndex, int tokenCount,
            string sourceCode, IPccRegExHandler pccRegExHandler)
        : base(lexeme, currentLine, currentIndex, tokenCount, sourceCode, pccRegExHandler)
        {
        }


        public override Task<IPccToken> Handle(CancellationToken cancellationToken)
        {
            try
            {
                if (isPeekADoubleQuote())
                {
                    ScanAllCharactersUpToTheNextDelimiter('"');
                    return DateFormatIsDDMMYYYY(cancellationToken);
                }
                else if (isPeekAnHashTag())
                {
                    ScanAllCharactersUpToTheNextDelimiter('#');
                    return DateFormatIsDDMMYYYY(cancellationToken);
                }
                return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.UNDEFINED, _lexeme, _currentLine));
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        protected Task<IPccToken> DateFormatIsDDMMYYYY(CancellationToken cancellationToken)
        {
            const string PATTERN_TO_MATCH = @"^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$";

            string dateLexeme = _pccRegExHandler.ValidateString(_lexeme, PATTERN_TO_MATCH, cancellationToken).Result;
            if (!string.IsNullOrEmpty(dateLexeme))
            {
                return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.DATE_DDmmYYYY, dateLexeme, 
                    _currentLine));
            }
            return DateFormatIsMMDDYYYY(cancellationToken);
        }


        protected Task<IPccToken> DateFormatIsMMDDYYYY(CancellationToken cancellationToken)
        {
            const string PATTERN_TO_MATCH = @"^(0[1-9]|1[012])[-/.](0[1-9]|[12][0-9]|3[01])[-/.](19|20)\d\d$";

            string dateLexeme = _pccRegExHandler.ValidateString(_lexeme, PATTERN_TO_MATCH, cancellationToken).Result;
            if (!string.IsNullOrEmpty(dateLexeme))
            {
                return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.DATE_MMddYYYY, dateLexeme, 
                    _currentLine));
            }
            return DateFormatIsYYYYMMDD(cancellationToken);
        }


        protected Task<IPccToken> DateFormatIsYYYYMMDD(CancellationToken cancellationToken)
        {
            const string PATTERN_TO_MATCH = @"^(19|20)\d{2}[-/.]((0[1-9])|(1[012]))[-/.]((0[1-9]|[12]\d)|3[01])$";

            string dateLexeme = _pccRegExHandler.ValidateString(_lexeme, PATTERN_TO_MATCH, cancellationToken).Result;
            if (!string.IsNullOrEmpty(dateLexeme))
            {
                return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.DATE_YYYYmmDD, dateLexeme, 
                    _currentLine));
            }
            return DateFormatIsMMMDDYYYY(cancellationToken);
        }


        protected Task<IPccToken> DateFormatIsMMMDDYYYY(CancellationToken cancellationToken)
        {
            const string PATTERN_TO_MATCH = @"^(JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC)[-/.]" +
                @"((0[1-9]|[12]\d)|3[01])[-/.](19|20)\d{2}$";

            string auxLexeme = _lexeme.ToUpper();
            string dateLexeme = _pccRegExHandler.ValidateString(auxLexeme, PATTERN_TO_MATCH, cancellationToken).Result;
            if (!string.IsNullOrEmpty(dateLexeme))
            {
                return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.DATE_MMMddYYYY, _lexeme,
                    _currentLine));
            }
            return DateFormatIsMMMMddYYYY(cancellationToken);
        }


        protected Task<IPccToken> DateFormatIsMMMMddYYYY(CancellationToken cancellationToken)
        {
            const string PATTERN_TO_MATCH = @"^(JANUARY|FEBRUARY|MARCH|APRIL|MAY|JUNE|JULY|AUGUST|SEPTEMBER|OCTOBER|" +
                @"NOVEMBER|DECEMBER)[ ]+((0[1-9]|[12]\d)|3[01]),[ ]*(19|20)\d{2}$";

            string auxLexeme = _lexeme.ToUpper();
            string dateLexeme = _pccRegExHandler.ValidateString(auxLexeme, PATTERN_TO_MATCH, cancellationToken).Result;
            if (!string.IsNullOrEmpty(dateLexeme))
            {
                return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.DATE_MMMMddYYYY, _lexeme,
                    _currentLine));
            }
            return DateTimeFormatIsDDddYYYY_HHMMSS(cancellationToken);
        }

        // Jan-31-2022
        // January 31, 2022

        protected Task<IPccToken> DateTimeFormatIsDDddYYYY_HHMMSS(CancellationToken cancellationToken)
        {
            const string PATTERN_TO_MATCH =
                @"^((0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d{2})[ ]+((0\d|1\d|2[0|1|2|3]):(0\d|1\d|" + 
                    @"2\d|3\d|4\d|5\d):(0\d|1\d|2\d|3\d|4\d|5\d))+$";

            string dateTimeLexeme = _pccRegExHandler.ValidateString(_lexeme, PATTERN_TO_MATCH, cancellationToken).Result;
            if (!string.IsNullOrEmpty(dateTimeLexeme))
            {
                return Task.FromResult<IPccToken>(
                    new PccToken(_tokenCount, ETokenName.DATE_TIME_DDmmYYYY_HHMMSS, dateTimeLexeme, _currentLine));
            }
            return DateTimeFormatIsMMDDYYYY_HHMMSS(cancellationToken);
        }


        protected Task<IPccToken> DateTimeFormatIsMMDDYYYY_HHMMSS(CancellationToken cancellationToken)
        {
            const string PATTERN_TO_MATCH = 
                @"^((0[1-9]|1[012])[-/.](0[1-9]|[12][0-9]|3[01])[-/.](19|20)\d{2})[ ]+((0\d|1\d|2[0|1|2|3]):(0\d|1\d|" + 
                    @"2\d|3\d|4\d|5\d):(0\d|1\d|2\d|3\d|4\d|5\d))+$";

            string dateTimeLexeme = _pccRegExHandler.ValidateString(_lexeme, PATTERN_TO_MATCH, cancellationToken).Result;
            if (!string.IsNullOrEmpty(dateTimeLexeme))
            {
                return Task.FromResult<IPccToken>(
                    new PccToken(_tokenCount, ETokenName.DATE_TIME_mmDDYYYY_HHMMSS, dateTimeLexeme, _currentLine));
            }
            return DateTimeFormatIsYYYYMMDD_HHMMSS(cancellationToken);
        }


        protected Task<IPccToken> DateTimeFormatIsYYYYMMDD_HHMMSS(CancellationToken cancellationToken)
        {
            const string PATTERN_TO_MATCH =
                @"^((19|20)\d{2}[-/.](0[1-9]|1[012])[-/.](0[1-9]|[12][0-9]|3[01]))[ ]+((0\d|1\d|2[0|1|2|3]):(0\d|1\d|" + 
                    @"2\d|3\d|4\d|5\d):(0\d|1\d|2\d|3\d|4\d|5\d))+$";

            string dateTimeLexeme = _pccRegExHandler.ValidateString(_lexeme, PATTERN_TO_MATCH, cancellationToken).Result;
            if (!string.IsNullOrEmpty(dateTimeLexeme))
            {
                return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.DATE_TIME_YYYYmmDD_HHMMSS, 
                    dateTimeLexeme, _currentLine));
            }
            return base.Handle(cancellationToken);
        }
    }
}
