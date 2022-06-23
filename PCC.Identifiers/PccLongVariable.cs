using System;


namespace PCC.Identifiers
{
    public class PccLongVariable : PccVariable
    {
        internal PccLongVariable()
        {
            _hasAllValidFields = false;
        }

        public int GetValue()
        {
            if (_hasAllValidFields)
            {
                int convertedValue = 0;

                if (int.TryParse(_value, out convertedValue)){
                    return convertedValue;
                }
                throw new OverflowException(string.Format("The variable '{0}' of type {1}, has an invalid value '{2}'",
                    Name, Type.ToString().ToLower(), _value));
            }
            throw new InvalidOperationException(string.Format("The '{0}' variable did not have its fields validated by " +
                "the 'Build' method, of the 'Director' class", Name));
        }
    }
}
