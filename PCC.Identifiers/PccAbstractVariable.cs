using System;


namespace PCC.Identifiers
{
    public abstract class PccVariable : PccIdentifier
    {
        protected string _value;
        protected bool _hasAllValidFields;

        internal void SetValue(string value)
        {
            _value = value;
        }

        public string GetValueInStringFormat() 
        {
            return _value;
        }

        internal void SetVariableAsValid()
        {
            _hasAllValidFields = true;
        }
    }
}
