using PCC.Core.Handlers;
using System;


namespace PCC.Identifiers
{
    public class PccDoubleVariable : PccVariable
    {
        private const byte NUMBER_DECIMAL_DIGITS_FOR_DOUBLE_TYPE = 15;
        private PccTruncateDecimalNumbersHandler _pccTruncateDecimalNumbersHandler;

        internal PccDoubleVariable()
        {
            _hasAllValidFields = false;
            _pccTruncateDecimalNumbersHandler = new PccTruncateDecimalNumbersHandler(NUMBER_DECIMAL_DIGITS_FOR_DOUBLE_TYPE);
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
