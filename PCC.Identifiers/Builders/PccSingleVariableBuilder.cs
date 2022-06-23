using PCC.Core.Validations;
using PCC.Identifiers.Validations.PCC.Variable.Single;
using System.Collections.Generic;


namespace PCC.Identifiers.Builders
{
    internal class PccSingleVariableBuilder : PccIdentifierBuilder<PccSingleVariable>
    {
        private PccSingleVariable _pccSingleVariable;

        internal override void Reset() 
        {
            _pccSingleVariable = new PccSingleVariable();
        }

        internal void BuildId(long id)
        {
            base.SetId(id, ref _pccSingleVariable);
        }

        internal void BuildIdParent(long? idParent)
        {
            base.SetIdParent(idParent, ref _pccSingleVariable);
        }

        internal void BuildName(string name)
        {
            base.SetName(name, ref _pccSingleVariable);
        }

        internal void BuildInitialPositionIntoTheCode(int initialPositionIntoTheCode)
        {
            base.SetInitialPositionIntoTheCode(initialPositionIntoTheCode, ref _pccSingleVariable);
        }

        internal void BuildFinalPositionIntoTheCode(int finalPositionIntoTheCode)
        {
            base.SetFinalPositionIntoTheCode(finalPositionIntoTheCode, ref _pccSingleVariable);
        }

        internal void BuildIdentifierScope(PccIdentifierScope pccIdentifierScope)
        {
            SetIdentifierScope(pccIdentifierScope, ref _pccSingleVariable);
        }

        internal void BuildIdentifierType()
        {
            _pccSingleVariable.SetType(PccIdentifierType.SINGLE);
        }

        internal void BuildIdentifierClass()
        {
            _pccSingleVariable.SetClass(PccIdentifierClass.VARIABLE);
        }

        internal void BuildValue(string value)
        {
            _pccSingleVariable.SetValue(value);
        }


        #region Get the builded variable only when all its fields already was validated.

        internal PccSingleVariable GetValidatedVariable()
        {
            LoadIdentifierValidators();
            if (ParseValidators())
            {
                _pccSingleVariable.SetVariableAsValid();
                return _pccSingleVariable;
            }
            return null;
        }

        private bool ParseValidators()
        {
            var variable = _pccSingleVariable;
            if (IsValidIdentifierFields(variable)){
                return ParseVariableSpecificValidators();
            }
            return false;
        }

        private bool ParseVariableSpecificValidators()
        {
            var variableValidators = new List<IValidator<PccSingleVariable>>();
            variableValidators.Add(new ValueIsntConversibleToSingleValuesValidator());
            variableValidators.Add(new InvalidCharactersForSingleNumbersValidator());

            if (IsValidVariableSpecificFields(variableValidators, _pccSingleVariable)){
                return true;
            }
            return false;
        }

        #endregion
    }
}
