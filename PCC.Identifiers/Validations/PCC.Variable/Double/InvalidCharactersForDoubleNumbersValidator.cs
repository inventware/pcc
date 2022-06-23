using PCC.Core.Validations;
using System;
using System.Collections.Generic;


namespace PCC.Identifiers.Validations.PCC.Variable.Double
{
    internal class InvalidCharactersForDoubleNumbersValidator : IValidator<PccDoubleVariable>
    {
        private IList<char> _validCharacters;

        internal InvalidCharactersForDoubleNumbersValidator()
        {
            _validCharacters = new List<char>();
            _validCharacters.Add('0');
            _validCharacters.Add('1');
            _validCharacters.Add('2');
            _validCharacters.Add('3');
            _validCharacters.Add('4');
            _validCharacters.Add('5');
            _validCharacters.Add('6');
            _validCharacters.Add('7');
            _validCharacters.Add('8');
            _validCharacters.Add('9');
            _validCharacters.Add('.');
            _validCharacters.Add('+');
            _validCharacters.Add('-');
            _validCharacters.Add('E');
            _validCharacters.Add('e');
        }

        public string GetMessage()
        {
            return "The number has invalid characters.";
        }

        /// <summary>
        /// IMPORTANT: 
        ///     In Basic a variable should be instanced with NULL/EMPTY value (e.g.: Dim nameVariable as Date).
        /// </summary>
        public bool IsValid(PccDoubleVariable pccDoubleVariable)
        {
            if (string.IsNullOrEmpty(pccDoubleVariable.GetValueInStringFormat())){
                return true;
            }
            return IsAValidValue(pccDoubleVariable);
        }

        public bool IsAValidValue(PccDoubleVariable pccDoubleVariable)
        {
            try
            {
                bool hasInvalidCharacter = false;

                foreach (var character in pccDoubleVariable.GetValueInStringFormat())
                {
                    if (!_validCharacters.Contains(character)){
                        hasInvalidCharacter = true;
                    }
                }
                return !hasInvalidCharacter;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
