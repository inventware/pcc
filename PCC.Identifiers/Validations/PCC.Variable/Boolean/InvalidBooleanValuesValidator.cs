using PCC.Core.Validations;
using System;


namespace PCC.Identifiers.Validations.PCC.Variable.Boolean
{
    internal class InvalidBooleanValuesValidator : IValidator<PccBooleanVariable>
    {
        public string GetMessage()
        {
            return "The variable has an invalid boolean value.";
        }

        /// <summary>
        /// IMPORTANT: 
        ///     In Basic a variable should be instanced with NULL/EMPTY value (e.g.: Dim nameVariable as Date).
        /// </summary>
        public bool IsValid(PccBooleanVariable pccBooleanVariable)
        {
            if (string.IsNullOrEmpty(pccBooleanVariable.GetValueInStringFormat())){
                return true;
            }
            return IsAValidValue(pccBooleanVariable);
        }
        public bool IsAValidValue(PccBooleanVariable pccBooleanVariable)
        {
            try
            {
                if (pccBooleanVariable.GetValueInStringFormat().ToString().ToUpper().Equals("TRUE") ||
                    pccBooleanVariable.GetValueInStringFormat().ToString().ToUpper().Equals("FALSE") ||
                    pccBooleanVariable.GetValueInStringFormat().Equals("0") ||
                    pccBooleanVariable.GetValueInStringFormat().Equals("1") ||
                    pccBooleanVariable.GetValueInStringFormat().Equals("-1"))
                {
                    return true;
                }
                return false;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
