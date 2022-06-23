using System;
using System.Threading;


namespace PCC.Core.Handlers
{
    /// <summary>
    /// REFERENCE:
    ///     https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types
    /// </summary>
    public class PccTruncateDecimalNumbersHandler
    {
        private byte _digitsNumberToTruncate;
        private char _symbolForDecimalSeparator;

        public PccTruncateDecimalNumbersHandler(byte digitsNumberToTruncate)
        {
            _digitsNumberToTruncate = digitsNumberToTruncate;
            _symbolForDecimalSeparator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
        }

        public double Truncate(string numberToFormat)
        {
            try
            {
                if (numberToFormat.ToUpper().Contains("E")) {
                    return TruncateScientificNotationNumber(numberToFormat);
                }

                if (numberToFormat.Contains(".")){
                    return TruncateDecimalNumber(numberToFormat);
                }

                return Convert.ToDouble(numberToFormat);
            }
            catch (Exception err)
            {
                throw new FormatException("It occurred an error during truncated proccess to number '" + 
                    numberToFormat + "'. (" + err.Message + ")");
            }
        }

        private double TruncateScientificNotationNumber(string numberToFormat)
        {
            string integerPartNumber = string.Empty;
            string decimalPartNumber = string.Empty;
            GetNumberPartsFromScientificNotationFormat(numberToFormat, ref integerPartNumber, ref decimalPartNumber);

            int numberOfSignificantDigits = Convert.ToInt32(numberToFormat.Substring(
                numberToFormat.ToUpper().IndexOf("E") + 1));

            if (numberOfSignificantDigits < 0){
                return TruncateScientificNotationForNegativeNumber(integerPartNumber, decimalPartNumber, numberOfSignificantDigits);
            }
            return TruncateScientificNotationForPositiveNumber(integerPartNumber, decimalPartNumber, numberOfSignificantDigits);
        }

        private void GetNumberPartsFromScientificNotationFormat(string numberToFormat, ref string integerPartNumber,
            ref string decimalPartNumber)
        {
            integerPartNumber = numberToFormat.Substring(0, numberToFormat.IndexOf("."));
            decimalPartNumber = numberToFormat.Substring(numberToFormat.IndexOf(".") + 1,
                (numberToFormat.IndexOf("E") - (numberToFormat.IndexOf(".") + 1)));
        }

        private double TruncateScientificNotationForNegativeNumber(string integerPartNumber, string decimalPartNumber, 
            int numberOfSignificantDigits)
        {
            try
            {
                double truncatedNumber = double.NaN;
                string auxTruncatedNumber = string.Empty;
                bool isANegativeNumber = integerPartNumber.Contains("-");
                integerPartNumber = integerPartNumber.Replace("-", "");

                if (Math.Abs(numberOfSignificantDigits) >= integerPartNumber.Length)
                {
                    auxTruncatedNumber = "0" + _symbolForDecimalSeparator + (GeneratesStringOfZerosAccordingTo(
                        Math.Abs(numberOfSignificantDigits) - integerPartNumber.Length) + integerPartNumber) + decimalPartNumber;
                }
                else    // Math.Abs(numberOfSignificantDigits) < integerPartNumber.Length
                {
                    auxTruncatedNumber = integerPartNumber.Substring(0, (integerPartNumber.Length - Math.Abs(
                        numberOfSignificantDigits))) + _symbolForDecimalSeparator + integerPartNumber.Substring((
                        integerPartNumber.Length - Math.Abs(numberOfSignificantDigits))) + decimalPartNumber;
                }

                auxTruncatedNumber = auxTruncatedNumber.Substring(0, auxTruncatedNumber.IndexOf(_symbolForDecimalSeparator) + 1) +
                    auxTruncatedNumber.Substring(auxTruncatedNumber.IndexOf(_symbolForDecimalSeparator) + 1, _digitsNumberToTruncate);
                if (double.TryParse(auxTruncatedNumber, out truncatedNumber)){
                    return isANegativeNumber? (-1) * truncatedNumber: truncatedNumber;
                }
                throw new ArgumentException();
            }
            catch (OverflowException)
            {
                throw new OverflowException(string.Format("Stack overflow, {0}.{1}E-{2} is too big a number.",
                    integerPartNumber, decimalPartNumber, numberOfSignificantDigits));
            }
        }

        private double TruncateScientificNotationForPositiveNumber(string integerPartNumber, string decimalPartNumber, 
            int numberOfSignificantDigits)
        {
            try
            {
                double truncatedNumber = double.NaN;
                string auxTruncatedNumber = string.Empty;
                bool isANegativeNumber = integerPartNumber.Contains("-");
                integerPartNumber = integerPartNumber.Replace("-", "");

                if (Math.Abs(numberOfSignificantDigits) >= decimalPartNumber.Length)
                {
                    auxTruncatedNumber = integerPartNumber + decimalPartNumber + GeneratesStringOfZerosAccordingTo(
                        Math.Abs(numberOfSignificantDigits) - decimalPartNumber.Length) + _symbolForDecimalSeparator +
                        GeneratesStringOfZerosAccordingTo(_digitsNumberToTruncate);

                }
                else    // Math.Abs(numberOfSignificantDigits) < decimalPartNumber.Length
                {
                    auxTruncatedNumber = integerPartNumber + decimalPartNumber.Substring(0, (decimalPartNumber.Length - Math.Abs(
                        numberOfSignificantDigits))) + _symbolForDecimalSeparator + decimalPartNumber.Substring((
                        decimalPartNumber.Length - Math.Abs(numberOfSignificantDigits))) + GeneratesStringOfZerosAccordingTo(
                            _digitsNumberToTruncate - (decimalPartNumber.Substring((decimalPartNumber.Length - 
                            Math.Abs(numberOfSignificantDigits)))).Length);
                }

                auxTruncatedNumber = auxTruncatedNumber.Substring(0, auxTruncatedNumber.IndexOf(_symbolForDecimalSeparator) + 1) +
                    auxTruncatedNumber.Substring(auxTruncatedNumber.IndexOf(_symbolForDecimalSeparator) + 1, _digitsNumberToTruncate);
                if (double.TryParse(auxTruncatedNumber, out truncatedNumber)){
                    return isANegativeNumber ? (-1) * truncatedNumber : truncatedNumber;
                }
                throw new ArgumentException();
            }
            catch (OverflowException)
            {
                throw new OverflowException(string.Format("Stack overflow, {0}.{1}E+{2} is too small a number.",
                    integerPartNumber, decimalPartNumber, numberOfSignificantDigits));
            }
        }

        private string GeneratesStringOfZerosAccordingTo(int numberOfSignificantDigits)
        {
            string sequenceOfZeros = "";
            for (int i = 0; i < Math.Abs(numberOfSignificantDigits); i++)
            {
                sequenceOfZeros += "0";
            }
            return sequenceOfZeros;
        }

        private double TruncateDecimalNumber(string numberToFormat) 
        {
            string integerPartNumber = numberToFormat.Substring(0, numberToFormat.IndexOf("."));
            string decimalPartNumber = numberToFormat.Substring(numberToFormat.IndexOf(".") + 1,
                _digitsNumberToTruncate > numberToFormat.Substring(numberToFormat.IndexOf(".") + 1).Length ? 
                    numberToFormat.Substring(numberToFormat.IndexOf(".") + 1).Length : _digitsNumberToTruncate);

            double auxNumber = -1;
            if (double.TryParse(integerPartNumber + _symbolForDecimalSeparator + decimalPartNumber, out auxNumber)){
                return auxNumber;
            }
            throw new InvalidOperationException(string.Format("It is not possible converts the value '{0}' for a double " +
                "number.", numberToFormat));
        }
    }
}
