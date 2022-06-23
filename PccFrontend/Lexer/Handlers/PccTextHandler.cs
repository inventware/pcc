using PCC.Core.Handlers;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace PCC.Frontend.Lexer.Handlers
{
    internal class PccTextHandler : PccCharactersHandler
    {
        internal PccTextHandler(string lexeme, int currentLine, int currentIndex, int tokenCount,
            string sourceCode, IPccRegExHandler pccRegExHandler)
        : base(lexeme, currentLine, currentIndex, tokenCount, sourceCode, pccRegExHandler)
        {
        }


        public override Task<IPccToken> Handle(CancellationToken cancellationToken)
        {
            if (isPeekALetter())
            {
                ScanLetterOrDigitOrUnderscoreCharacters(ref _lexeme);
                return IsTheLexemeAVisualBasicKeyword(cancellationToken);
            }
            return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.UNDEFINED, _lexeme, _currentLine));
        }


        public Task<IPccToken> IsTheLexemeAVisualBasicKeyword(CancellationToken cancellationToken)
        {
            object tokenName = null;
            if (Enum.TryParse(typeof(ETokenName), _lexeme.ToUpper(), out tokenName))
            {
                var auxTokenName = (ETokenName)tokenName;
                return Task.FromResult<IPccToken>(new PccToken(_tokenCount, auxTokenName, _lexeme, _currentLine));
            }
            return IsTheLexemeAMathFunction(cancellationToken);
        }


        /// <summary>
        /// REFERENCE:
        ///     https://docs.microsoft.com/en-us/office/vba/language/reference/functions-visual-basic-for-applications
        /// </summary>
        public Task<IPccToken> IsTheLexemeAMathFunction(CancellationToken cancellationToken)
        {
            switch (_lexeme.ToUpper())
            {
                case "ABS":
                    return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.ABS_FUNC, _lexeme, _currentLine));
                
                case "ATN":
                    return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.ATN_FUNC, _lexeme, _currentLine));
                
                case "COS":
                    return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.COS_FUNC, _lexeme, _currentLine));
                               
                case "EXP":
                    return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.EXP_FUNC, _lexeme, _currentLine));
                
                case "INT":
                    return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.INT_FUNC, _lexeme, _currentLine));
                
                case "FIX":
                    return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.FIX_FUNC, _lexeme, _currentLine));
                
                case "LOG":
                    return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.LOG_FUNC, _lexeme, _currentLine));

                case "MOD":
                    return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.MOD_OP, _lexeme, _currentLine));

                case "RND":
                    return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.RND_FUNC, _lexeme, _currentLine));
                
                case "SGN":
                    return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.SGN_FUNC, _lexeme, _currentLine));
                
                case "SIN":
                    return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.SIN_FUNC, _lexeme, _currentLine));
                
                case "SQR":
                    return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.SQR_FUNC, _lexeme, _currentLine));
                
                case "TAN":
                    return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.TAN_FUNC, _lexeme, _currentLine));

                default:
                    return IsTheLexemeAConversionFunction(cancellationToken);
            }
        }


        /// <summary>
        /// REFERENCE:
        ///     https://docs.microsoft.com/en-us/office/vba/language/reference/functions-visual-basic-for-applications
        /// </summary>
        public Task<IPccToken> IsTheLexemeAConversionFunction(CancellationToken cancellationToken)
        {
            switch (_lexeme.ToUpper())
            {
                case "ASC":
                    return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.ASC_FUNC, _lexeme, _currentLine));

                case "CHR":
                    return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.CHR_FUNC, _lexeme, _currentLine));

                case "CVERR":
                    return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.CVERR_FUNC, _lexeme, _currentLine));

                case "FORMAT":
                    return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.FORMAT_FUNC, _lexeme, _currentLine));

                case "HEX":
                    return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.HEX_FUNC, _lexeme, _currentLine));

                case "OCT":
                    return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.OCT_FUNC, _lexeme, _currentLine));

                case "STR":
                    return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.STR_FUNC, _lexeme, _currentLine));

                case "VAL":
                    return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.VAL_FUNC, _lexeme, _currentLine));

                default:
                    return IsTheLexemeAnIdentifier(cancellationToken);
            }
        }

        public Task<IPccToken> IsTheLexemeAnIdentifier(CancellationToken cancellationToken)
        {
            if (_lexeme.Length > 255){
                throw new ArgumentOutOfRangeException("The identifier '" + _lexeme + "' exceeds 255 characters.");
            }
            return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.ID, _lexeme, _currentLine));
        }
    }
}
