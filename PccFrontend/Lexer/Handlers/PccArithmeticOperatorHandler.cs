using PCC.Core.Handlers;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace PCC.Frontend.Lexer.Handlers
{
    internal class PccArithmeticOperatorHandler : PccCharactersHandler
    {
        internal PccArithmeticOperatorHandler(string lexeme, int currentLine, int currentIndex, int tokenCount,
            string sourceCode, IPccRegExHandler pccRegExHandler)
        : base(lexeme, currentLine, currentIndex, tokenCount, sourceCode, pccRegExHandler)
        {
        }


        /// <summary>
        /// REFERENCE:
        ///     https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/language-features/operators-and-expressions/arithmetic-operators
        /// </summary>
        /// <returns></returns>
        public override Task<IPccToken> Handle(CancellationToken cancellationToken)
        {
            try
            {
                switch (_peek)
                {
                    case '+':
                        IncrCurrentIndex();
                        return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.ADD_OP, "+", _currentLine));

                    case '-':
                        IncrCurrentIndex();
                        return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.SUB_OP, "-", _currentLine));

                    case '*':
                        IncrCurrentIndex();
                        return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.MULT_OP, "*", _currentLine));

                    case '/':
                        IncrCurrentIndex();
                        return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.DIV_OP, "/", _currentLine));

                    case '^':
                        IncrCurrentIndex();
                        return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.EXP_OP, "^", _currentLine));

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
