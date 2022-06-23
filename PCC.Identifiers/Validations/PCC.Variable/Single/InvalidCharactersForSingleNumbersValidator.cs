using PCC.Core.Validations;
using System;
using System.Collections.Generic;


namespace PCC.Identifiers.Validations.PCC.Variable.Single
{
    internal class InvalidCharactersForSingleNumbersValidator : IValidator<PccSingleVariable>
    {
        IList<char> _validCharacters;

        internal InvalidCharactersForSingleNumbersValidator()
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
        public bool IsValid(PccSingleVariable pccSingleVariable)
        {
            if (string.IsNullOrEmpty(pccSingleVariable.GetValueInStringFormat())){
                return true;
            }
            return IsAValidValue(pccSingleVariable);
        }

        public bool IsAValidValue(PccSingleVariable pccSingleVariable)
        {
            try
            {
                bool hasInvalidCharacter = false;

                foreach (var character in pccSingleVariable.GetValueInStringFormat())
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
