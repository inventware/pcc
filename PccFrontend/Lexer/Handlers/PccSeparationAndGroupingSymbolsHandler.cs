using PCC.Core.Handlers;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace PCC.Frontend.Lexer.Handlers
{
    internal class PccSeparationAndGroupingSymbolsHandler : PccCharactersHandler
    {
        internal PccSeparationAndGroupingSymbolsHandler(string lexeme, int currentLine, int currentIndex, int tokenCount,
            string sourceCode, IPccRegExHandler pccRegExHandler)
        : base(lexeme, currentLine, currentIndex, tokenCount, sourceCode, pccRegExHandler)
        {
        }

        public override Task<IPccToken> Handle(CancellationToken cancellationToken)
        {
            try
            {
                switch (_peek)
                {
                    case '(':
                        IncrCurrentIndex();
                        return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.OPEN_BRACKET, "(", _currentLine));

                    case ')':
                        IncrCurrentIndex();
                        return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.CLOSE_BRACKET, ")", _currentLine));
                    
                    case '[':
                        IncrCurrentIndex();
                        return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.OPEN_SQUARE_BRACKET, "[", _currentLine));

                    case ']':
                        IncrCurrentIndex();
                        return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.CLOSE_SQUARE_BRACKET, "]", _currentLine));

                    case '{':
                        IncrCurrentIndex();
                        return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.OPEN_BRACE, "{", _currentLine));

                    case '}':
                        IncrCurrentIndex();
                        return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.CLOSE_BRACE, "}", _currentLine));

                    case ',':
                        IncrCurrentIndex();
                        return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.COMMA, ",", _currentLine));

                    case ';':
                        IncrCurrentIndex();
                        return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.SEMICOLON, ";", _currentLine));

                    case ':':
                        IncrCurrentIndex();
                        return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.COLON, ":", _currentLine));

                    case '.':
                        IncrCurrentIndex();
                        return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.POINT, ".", _currentLine));

                    case '&':
                        IncrCurrentIndex();
                        return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.CONCAT_OP, "&", _currentLine));

                    case '_':
                        IncrCurrentIndex();
                        return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.UNDERSCORE, "_", _currentLine));

                    default:
                        return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.UNDEFINED, _lexeme, _currentLine));
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
