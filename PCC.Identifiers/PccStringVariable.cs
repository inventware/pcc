using System;

namespace PCC.Identifiers
{
    public class PccStringVariable : PccVariable
    {
        internal PccStringVariable()
        {
            _hasAllValidFields = false;
        }

        public string GetValue()
        {
            if (_hasAllValidFields){
                return _value;
            }
            throw new InvalidOperationException(string.Format("The '{0}' variable did not have its fields validated by " +
                "the 'Build' method, of the 'Director' class", Name));
        }
    }
}
