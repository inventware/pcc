using PCC.Core.Handlers;
using System;


namespace PCC.Identifiers
{
    public class PccSingleVariable : PccVariable
    {
        private const byte NUMBER_DECIMAL_DIGITS_FOR_SINGLE_TYPE = 7;
        private PccTruncateDecimalNumbersHandler _pccTruncateDecimalNumbersHandler;

        internal PccSingleVariable()
        {
            _hasAllValidFields = false;
            _pccTruncateDecimalNumbersHandler = new PccTruncateDecimalNumbersHandler(NUMBER_DECIMAL_DIGITS_FOR_SINGLE_TYPE);
        }

        public double GetValue()
        {
            if (_hasAllValidFields){
                return _pccTruncateDecimalNumbersHandler.Truncate(_value);
            }
            throw new InvalidOperationException(string.Format("The '{0}' variable did not have its fields validated by " + 
                "the 'Build' method, of the 'Director' class", Name));
        }
    }
}
