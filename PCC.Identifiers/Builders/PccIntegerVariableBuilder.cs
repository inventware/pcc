using PCC.Core.Validations;
using PCC.Identifiers.Validations.PCC.Variable.Integer;
using System.Collections.Generic;


namespace PCC.Identifiers.Builders
{
    internal class PccIntegerVariableBuilder : PccIdentifierBuilder<PccIntegerVariable>
    {
        private PccIntegerVariable _pccIntegerVariable;

        internal override void Reset() 
        {
            _pccIntegerVariable = new PccIntegerVariable();
        }
        internal void BuildId(long id)
        {
            base.SetId(id, ref _pccIntegerVariable);
        }
        internal void BuildIdParent(long? idParent)
        {
            base.SetIdParent(idParent, ref _pccIntegerVariable);
        }
        internal void BuildName(string name)
        {
            base.SetName(name, ref _pccIntegerVariable);
        }
        internal void BuildInitialPositionIntoTheCode(int initialPositionIntoTheCode)
        {
            base.SetInitialPositionIntoTheCode(initialPositionIntoTheCode, ref _pccIntegerVariable);
        }
        internal void BuildFinalPositionIntoTheCode(int finalPositionIntoTheCode)
        {
            base.SetFinalPositionIntoTheCode(finalPositionIntoTheCode, ref _pccIntegerVariable);
        }
        internal void BuildIdentifierScope(PccIdentifierScope pccIdentifierScope)
        {
            SetIdentifierScope(pccIdentifierScope, ref _pccIntegerVariable);
        }
        internal void BuildIdentifierType()
        {
            _pccIntegerVariable.SetType(PccIdentifierType.INTEGER);
        }
        internal void BuildIdentifierClass()
        {
            _pccIntegerVariable.SetClass(PccIdentifierClass.VARIABLE);
        }
        internal void BuildValue(string value)
        {
            _pccIntegerVariable.SetValue(value);
        }


        #region Get the builded variable only when all its fields already was validated.

        internal PccIntegerVariable GetValidatedVariable()
        {
            LoadIdentifierValidators();
            if (ParseValidators())
            {
                _pccIntegerVariable.SetVariableAsValid();
                return _pccIntegerVariable;
            }
            return null;
        }

        private bool ParseValidators()
        {
            var variable = _pccIntegerVariable;
            if (IsValidIdentifierFields(variable)){
                return ParseVariableSpecificValidators();
            }
            return false;
        }

        private bool ParseVariableSpecificValidators()
        {
            var variableValidators = new List<IValidator<PccIntegerVariable>>();
            variableValidators.Add(new IntegerValuesOutOfRangeAllowedValuesValidator());

            if (IsValidVariableSpecificFields(variableValidators, _pccIntegerVariable)){
                return true;
            }
            return false;
        }

        #endregion
    }
}
