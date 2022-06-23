using PCC.Core.Validations;
using PCC.Identifiers.Validations.PCC.Variable.Boolean;
using System.Collections.Generic;


namespace PCC.Identifiers.Builders
{
    internal class PccBooleanVariableBuilder : PccIdentifierBuilder<PccBooleanVariable>
    {
        private PccBooleanVariable _pccBooleanVariable;

        internal override void Reset() 
        {
            _pccBooleanVariable = new PccBooleanVariable();
        }

        internal void BuildId(long id)
        {
            base.SetId(id, ref _pccBooleanVariable);
        }

        internal void BuildIdParent(long? idParent)
        {
            base.SetIdParent(idParent, ref _pccBooleanVariable);
        }

        internal void BuildName(string name)
        {
            base.SetName(name, ref _pccBooleanVariable);
        }

        internal void BuildInitialPositionIntoTheCode(int initialPositionIntoTheCode)
        {
            base.SetInitialPositionIntoTheCode(initialPositionIntoTheCode, ref _pccBooleanVariable);
        }

        internal void BuildFinalPositionIntoTheCode(int finalPositionIntoTheCode)
        {
            base.SetFinalPositionIntoTheCode(finalPositionIntoTheCode, ref _pccBooleanVariable);
        }

        internal void BuildIdentifierScope(PccIdentifierScope pccIdentifierScope)
        {
            SetIdentifierScope(pccIdentifierScope, ref _pccBooleanVariable);
        }

        internal void BuildIdentifierType()
        {
            _pccBooleanVariable.SetType(PccIdentifierType.BOOLEAN);
        }

        internal void BuildIdentifierClass()
        {
            _pccBooleanVariable.SetClass(PccIdentifierClass.VARIABLE);
        }

        internal void BuildValue(string value)
        {
            if (!string.IsNullOrEmpty(value)){
                _pccBooleanVariable.SetValue(value);
            }
        }


        #region Get the builded variable only when all its fields already was validated.

        internal PccBooleanVariable GetValidatedVariable()
        {
            LoadIdentifierValidators();
            if (ParseValidators())
            {
                _pccBooleanVariable.SetVariableAsValid();
                return _pccBooleanVariable;
            }
            return null;
        }

        private bool ParseValidators()
        {
            var variable = _pccBooleanVariable;
            if (IsValidIdentifierFields(variable)){
                return ParseVariableSpecificValidators();
            }
            return false;
        }

        private bool ParseVariableSpecificValidators()
        {
            var variableValidators = new List<IValidator<PccBooleanVariable>>();
            variableValidators.Add(new InvalidBooleanValuesValidator());

            if (IsValidVariableSpecificFields(variableValidators, _pccBooleanVariable)){
                return true;
            }
            return false;
        }

        #endregion
    }
}
