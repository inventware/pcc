using PCC.Core.Validations;
using System;

namespace PCC.Identifiers.Validations.PCC.Variable.Integer
{
    internal class LongValuesOutOfRangeAllowedValuesValidator : IValidator<PccLongVariable>
    {
        public string GetMessage()
        {
            return "The allowed values of 'long' variable can range from -2147483648 to 2147483647.";
        }

        /// <summary>
        /// IMPORTANT: 
        ///     In Basic a variable should be instanced with NULL/EMPTY value (e.g.: Dim nameVariable as Date).
        /// </summary>
        public bool IsValid(PccLongVariable pccLongVariable)
        {
            if (string.IsNullOrEmpty(pccLongVariable.GetValueInStringFormat())){
                return true;
            }
            return IsAValidValue(pccLongVariable);
        }

        public bool IsAValidValue(PccLongVariable pccLongVariable)
        {
            try
            {
                int variableValue = int.MinValue;

                if (int.TryParse(pccLongVariable.GetValueInStringFormat(), out variableValue))
                {
                    const int MIN_VALUE_FOR_LONG_TYPE = -2147483648;
                    const int MAX_VALUE_FOR_LONG_TYPE = 2147483647;

                    if (variableValue < MIN_VALUE_FOR_LONG_TYPE || variableValue > MAX_VALUE_FOR_LONG_TYPE){
                        return false;
                    }
                    return true;
                }
                throw new ArgumentException(string.Format("It's not possible to convert the variable '{0}' which value " +
                    "is {1}, for the 'long' type.", pccLongVariable.Name, pccLongVariable.GetValueInStringFormat()) +
                    " - " + GetMessage());
            }
            catch (OverflowException errOverFlow)
            {
                throw errOverFlow;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
