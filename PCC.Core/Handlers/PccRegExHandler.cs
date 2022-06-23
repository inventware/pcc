using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;


namespace PCC.Core.Handlers
{
    public class PccRegExHandler : IPccRegExHandler
    {
        public PccRegExHandler() { }


        public Task<string> ValidateChar(char charToValidate, string patternToMatch, CancellationToken
            cancellationToken)
        {
            try
            {
                Regex regex = new Regex(patternToMatch);
                if (regex.IsMatch(Convert.ToString(charToValidate)))
                {
                    Match matchedResult = regex.Match(Convert.ToString(charToValidate));
                    return Task.FromResult<string>(matchedResult.ToString());
                }
                else
                {
                    return Task.FromResult<string>(string.Empty);
                }
            }
            catch (Exception err)
            {
                throw new OperationCanceledException(err.Message, cancellationToken);
            }
        }


        public Task<string> ValidateString(string charToValidate, string patternToMatch, CancellationToken
            cancellationToken)
        {
            try
            {
                Regex regex = new Regex(patternToMatch);
                if (regex.IsMatch(charToValidate))
                {
                    Match matchedResult = regex.Match(charToValidate);
                    return Task.FromResult<string>(matchedResult.ToString());
                }
                else
                {
                    return Task.FromResult<string>(string.Empty);
                }
            }
            catch (StackOverflowException stackOverErr)
            {
                throw new OperationCanceledException(stackOverErr.Message, cancellationToken);
            }
            catch (Exception err)
            {
                throw new OperationCanceledException(err.Message, cancellationToken);
            }
        }
    }
}
