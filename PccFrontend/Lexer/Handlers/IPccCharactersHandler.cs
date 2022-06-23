using System.Threading;
using System.Threading.Tasks;


namespace PCC.Frontend.Lexer.Handlers
{
    public interface IPccCharactersHandler
    {
        string Lexeme { get; set; }

        int CurrentIndex { get; set; }

        int CurrentLine { get; set; }

        char Peek { get; }

        IPccCharactersHandler SetNext(IPccCharactersHandler handler);

        Task<IPccToken> Handle(CancellationToken cancellationToken);
    }
}
