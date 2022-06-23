using PCC.Core.Validations;
using System;


namespace PCC.Identifiers.Validations.PCC.Variable.Integer
{
    internal class IntegerValuesOutOfRangeAllowedValuesValidator : IValidator<PccIntegerVariable>
    {
        public string GetMessage()
        {
            return "The allowed values of 'integer' variable can range from -32768 to 32767.";
        }

        /// <summary>
        /// IMPORTANT: 
        ///     In Basic a variable should be instanced with NULL/EMPTY value (e.g.: Dim nameVariable as Date).
        /// </summary>
        public bool IsValid(PccIntegerVariable pccIntegerVariable)
        {
            if (string.IsNullOrEmpty(pccIntegerVariable.GetValueInStringFormat())){
                return true;
            }
            return IsAValidValue(pccIntegerVariable);
        }

        public bool IsAValidValue(PccIntegerVariable pccIntegerVariable)
        {
            try
            {
                Int16 variableValue = Int16.MinValue;

                if (Int16.TryParse(pccIntegerVariable.GetValueInStringFormat(), out variableValue))
                {
                    const Int16 MIN_VALUE_FOR_INTEGER_TYPE = -32768;
                    const Int16 MAX_VALUE_FOR_INTEGER_TYPE = 32767;

                    if (variableValue < MIN_VALUE_FOR_INTEGER_TYPE || variableValue > MAX_VALUE_FOR_INTEGER_TYPE) {
                        return false;
                    }
                    return true;
                }
                throw new ArgumentException(string.Format("It's not possible to convert the variable '{0}' which value " +
                    "is {1}, for the 'integer' type.", pccIntegerVariable.Name, pccIntegerVariable.GetValueInStringFormat()) +
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
