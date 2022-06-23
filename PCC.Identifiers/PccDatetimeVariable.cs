using System;
using System.Globalization;


namespace PCC.Identifiers
{
    public class PccDatetimeVariable : PccVariable
    {
        protected string _dataFormat;
        internal PccDatetimeVariable()
        {
            _hasAllValidFields = false;
            _dataFormat = "MMddyyyyHHmmss";    //<-- Default value.
        }

        internal void SetDataFormat(string dataFormat)
        {
            _dataFormat = dataFormat;
        }
        public string GetDataFormat()
        {
            return _dataFormat;
        }
        public DateTime GetValue()
        {
            if (_hasAllValidFields){
                return GetConvertedValue();
            }
            throw new InvalidOperationException(string.Format("The '{0}' variable did not have its fields validated by " +
                "the 'Build' method, of the 'Director' class", Name));
        }
        private DateTime GetConvertedValue()
        {
            if (!string.IsNullOrEmpty(_dataFormat) && !string.IsNullOrEmpty(_value))
            {
                string auxDatetimeVariable = _value
                    .Replace(" ", "")
                    .Replace(".", "")
                    .Replace("/", "")
                    .Replace("-", "")
                    .Replace(":", "");
                return DateTime.ParseExact(auxDatetimeVariable, _dataFormat, CultureInfo.CurrentCulture);
            }
            throw new OverflowException(string.Format("The variable '{0}' of type {1}, has an invalid value '{2}'",
                Name, Type.ToString().ToLower(), _dataFormat));
        }
    }
}
