using System.Threading;
using System.Threading.Tasks;


namespace PCC.Core.Handlers
{
    public interface IPccRegExHandler
    {
        Task<string> ValidateChar(char charToValidate, string patternToMatch, CancellationToken cancellationToken);

        Task<string> ValidateString(string charToValidate, string patternToMatch, CancellationToken cancellationToken);
    }
}