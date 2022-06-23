using PCC.Core.Validations;
using System;
using System.Globalization;

namespace PCC.Identifiers.Validations.PCC.Variable.Single
{
    internal class ValueIsntConversibleToSingleValuesValidator : IValidator<PccSingleVariable>
    {
        /// <summary>
        /// IMPORTANT: 
        ///     Is not needed testing MIN and MAX values, because:
        ///         const int MIN_NUMBER_OF_SIGNIFICANT_DIGITS_FOR_SINGLE_TYPE = -Infinity;
        ///         const int MAX_NUMBER_OF_SIGNIFICANT_DIGITS_FOR_SINGLE_TYPE = +Infinity;
        /// (*) Only precision is relevant in this case.
        /// </summary>
        const Int16 MIN_NUMBER_OF_SIGNIFICANT_DIGITS_FOR_SINGLE_TYPE = -45;
        const Int16 MAX_NUMBER_OF_SIGNIFICANT_DIGITS_FOR_SINGLE_TYPE = 45;

        public string GetMessage()
        {
            return "The allowed values of 'single' variable can range from -3.402823E38 to -1.401298E-45 " +
                "for negative numbers and 1.401298E-45 to 3.402823E38 for positive numbers.";
        }

        /// <summary>
        /// IMPORTANT: 
        ///     In Basic a variable should be instanced with NULL/EMPTY value (e.g.: Dim nameVariable as Date).
        /// </summary>
        public bool IsValid(PccSingleVariable pccSingleVariable)
        {
            if (string.IsNullOrEmpty(pccSingleVariable.GetValueInStringFormat())){
                return true;
            }
            return IsAValidValue(pccSingleVariable);
        }

        private bool IsAValidValue(PccSingleVariable pccSingleVariable)
        {
            try
            {
                double convertedValue = 0;
                if (double.TryParse(pccSingleVariable.GetValueInStringFormat(), NumberStyles.Any, CultureInfo.InvariantCulture, 
                    out convertedValue))
                {
                    return IsANumberInScientificNotation(pccSingleVariable.GetValueInStringFormat());
                }
                return false;
            }
            catch (OverflowException errOverFlow)
            {
                throw errOverFlow;
            }
            catch (Exception err)
            {
                throw new OverflowException(string.Format("It occurred an error in the validation of {0} for the " +
                    "value({1}) ({2}).", pccSingleVariable.Name, pccSingleVariable.GetValueInStringFormat(), err.Message));
            }
        }

        private bool IsANumberInScientificNotation(string value)
        {
            if (value.ToUpper().Contains("E"))
            {
                return IsTheNumberInTheMinAndMaxRange(value, Convert.ToInt32(value.Substring(
                    value.ToUpper().IndexOf("E") + 1)));
            }
            return true;
        }

        private bool IsTheNumberInTheMinAndMaxRange(string value, int numberOfSignificantDigits)
        {
            if (numberOfSignificantDigits > MAX_NUMBER_OF_SIGNIFICANT_DIGITS_FOR_SINGLE_TYPE) {
                throw new OverflowException(string.Format("Stack overflow, {0} is too big a number.", value));
            }
            else if (numberOfSignificantDigits < MIN_NUMBER_OF_SIGNIFICANT_DIGITS_FOR_SINGLE_TYPE) {
                throw new OverflowException(string.Format("Stack overflow, {0} is too small a number.", value));
            }
            else {
                return true;
            }
        }
    }
}
