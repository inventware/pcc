using PCC.Core.Validations;
using System;
using System.Globalization;

namespace PCC.Identifiers.Validations.PCC.Variable.Date
{
    internal class DatetimeHasAValidValueValidator : IValidator<PccDatetimeVariable>
    {
        public string GetMessage()
        {
            return "The variable has an invalid datetime value.";
        }

        /// <summary>
        /// IMPORTANT: 
        ///     In Basic a variable should be instanced with NULL/EMPTY value (e.g.: Dim nameVariable as Date).
        /// </summary>
        public bool IsValid(PccDatetimeVariable pccDatetimeVariable)
        {
            if (string.IsNullOrEmpty(pccDatetimeVariable.GetDataFormat())){
                throw new OverflowException(string.Format("The DataFormat field doesn't founded for the variable '{0}').", 
                    pccDatetimeVariable.Name));
            }

            if (string.IsNullOrEmpty(pccDatetimeVariable.GetValueInStringFormat())){
                return true;
            }
            return IsAValueValid(pccDatetimeVariable);
        }

        private bool IsAValueValid(PccDatetimeVariable pccDatetimeVariable)
        {
            try
            {
                DateTime convertedValue = DateTime.Now;
                string auxDatetimeVariable = pccDatetimeVariable.GetValueInStringFormat()
                    .Replace(" ", "")
                    .Replace(".", "")
                    .Replace("/", "")
                    .Replace("-", "")
                    .Replace(":", "");

                if (DateTime.TryParseExact(auxDatetimeVariable, pccDatetimeVariable.GetDataFormat(), 
                    CultureInfo.CurrentCulture, DateTimeStyles.None, out convertedValue))
                {
                    return true;
                }
                return false;
            }
            catch (Exception err)
            {
                throw new OverflowException(string.Format("It occurred an error in the validation of {0} for the " +
                    "value({1}) ({2}).", pccDatetimeVariable.Name, pccDatetimeVariable.GetValueInStringFormat(), err.Message));
            }
        }
    }
}
