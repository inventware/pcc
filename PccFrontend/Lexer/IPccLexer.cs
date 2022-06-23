using System.Threading.Tasks;

namespace PCC.Frontend.Lexer
{
    public interface IPccLexer
    {
        Task<IPccToken> GetNextToken(int tokenCount);
    }
}