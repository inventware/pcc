using PCC.Core.Validations;
using System.Linq;
using System.Collections.Generic;


namespace PCC.Identifiers.Validations.PCC.Variable.Date
{
    internal class DatetimeHasAValidFormatValidator : IValidator<PccDatetimeVariable>
    {
        IList<string> _listOfDataFormats;

        internal DatetimeHasAValidFormatValidator()
        {
            _listOfDataFormats = new List<string>();
            // Short Date
            _listOfDataFormats.Add("yyyyMMdd");
            _listOfDataFormats.Add("MMddyyyy");
            _listOfDataFormats.Add("ddMMyyyy");

            // Long Date + Time
            _listOfDataFormats.Add("yyyyMMddHHmmss");
            _listOfDataFormats.Add("MMddyyyyHHmmss");
            _listOfDataFormats.Add("ddMMyyyyHHmmss");
            _listOfDataFormats.Add("dddMMyyyyHHmmss");
            _listOfDataFormats.Add("yyyyMMddHHmmssfff");
            _listOfDataFormats.Add("MMddyyyyHHmmssfff");
            _listOfDataFormats.Add("ddMMyyyyHHmmssfff");
            _listOfDataFormats.Add("dddMMyyyyHHmmssfff");

            // Time
            _listOfDataFormats.Add("HHmmss");
            _listOfDataFormats.Add("HHmmssfff");
        }


        public string GetMessage()
        {
            return "The variable has an invalid datetime format.";
        }

        /// <summary>
        /// IMPORTANT: 
        ///     In Basic a variable should be instanced with NULL/EMPTY value (e.g.: Dim nameVariable as Date).
        /// </summary>
        public bool IsValid(PccDatetimeVariable pccDatetimeVariable)
        {
            if (string.IsNullOrEmpty(pccDatetimeVariable.GetDataFormat())){
                return false;
            }
            return _listOfDataFormats.Where(dataFormatItem => dataFormatItem.Equals(pccDatetimeVariable.GetDataFormat())).Any();
        }
    }
}
