using PCC.Core.Handlers;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace PCC.Frontend.Lexer.Handlers
{
    internal class PccLogicalOperatorHandler : PccCharactersHandler
    {
        internal PccLogicalOperatorHandler(string lexeme, int currentLine, int currentIndex, int tokenCount,
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
                    case '=':
                        IncrCurrentIndex();
                        return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.EQUAL_OP, "=", _currentLine));

                    case '<':
                        _peek = GetNextCharOfSourceCode();
                        if (_peek == '=')
                        {
                            IncrCurrentIndex();
                            return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.LESS_THAN_OR_EQUAL_OP,
                                "<=", _currentLine));
                        }
                        return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.LESS_THAN_OP, "<",
                            _currentLine));

                    case '>':
                        _peek = GetNextCharOfSourceCode();
                        if (_peek == '=')
                        {
                            IncrCurrentIndex();
                            return Task.FromResult<IPccToken>(new PccToken(_tokenCount,
                                ETokenName.GREATER_THAN_OR_EQUAL_OP, ">=", _currentLine));
                        }
                        return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.GREATER_THAN_OP, ">",
                            _currentLine));

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
