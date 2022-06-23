using System;


namespace PCC.Identifiers
{
    public class PccBooleanVariable : PccVariable
    {
        private const bool INITIAL_DEFAULT_VALUE_FOR_BASIC_LANGUAGE = false;

        internal PccBooleanVariable()
        {
            _hasAllValidFields = false;
            _value = INITIAL_DEFAULT_VALUE_FOR_BASIC_LANGUAGE.ToString();
        }

        public bool GetValue()
        {
            if (_hasAllValidFields){
                return GetConvertedValue();
            }
            throw new InvalidOperationException(string.Format("The '{0}' variable did not have its fields validated by " +
                "the 'Build' method, of the 'Director' class", Name));
        }

        public bool GetConvertedValue()
        {
            bool convertedValue = INITIAL_DEFAULT_VALUE_FOR_BASIC_LANGUAGE;

            if (bool.TryParse(_value, out convertedValue)){
                return convertedValue;
            }
            else if (_value.Equals("-1") || _value.Equals("1")){
                return true;
            }
            else if (_value.Equals("0")){
                return false;
            }

            throw new OverflowException(string.Format("The variable '{0}' of type {1}, has an invalid value '{2}'",
                Name, Type.ToString().ToLower(), _value));
        }
    }
}
