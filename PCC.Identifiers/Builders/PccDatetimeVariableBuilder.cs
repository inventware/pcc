using PCC.Core.Validations;
using PCC.Identifiers.Validations.PCC.Variable.Date;
using System.Collections.Generic;


namespace PCC.Identifiers.Builders
{
    internal class PccDatetimeVariableBuilder : PccIdentifierBuilder<PccDatetimeVariable>
    {
        private PccDatetimeVariable _pccDatetimeVariable;

        internal override void Reset() 
        {
            _pccDatetimeVariable = new PccDatetimeVariable();
        }

        internal void BuildId(long id)
        {
            base.SetId(id, ref _pccDatetimeVariable);
        }

        internal void BuildIdParent(long? idParent)
        {
            base.SetIdParent(idParent, ref _pccDatetimeVariable);
        }

        internal void BuildName(string name)
        {
            base.SetName(name, ref _pccDatetimeVariable);
        }

        internal void BuildInitialPositionIntoTheCode(int initialPositionIntoTheCode)
        {
            base.SetInitialPositionIntoTheCode(initialPositionIntoTheCode, ref _pccDatetimeVariable);
        }

        internal void BuildFinalPositionIntoTheCode(int finalPositionIntoTheCode)
        {
            base.SetFinalPositionIntoTheCode(finalPositionIntoTheCode, ref _pccDatetimeVariable);
        }

        internal void BuildIdentifierScope(PccIdentifierScope pccIdentifierScope)
        {
            SetIdentifierScope(pccIdentifierScope, ref _pccDatetimeVariable);
        }

        internal void BuildIdentifierType()
        {
            _pccDatetimeVariable.SetType(PccIdentifierType.DATE);
        }

        internal void BuildIdentifierClass()
        {
            _pccDatetimeVariable.SetClass(PccIdentifierClass.VARIABLE);
        }

        internal void BuildDataFormat(string dataFormat)
        {
            if (!string.IsNullOrEmpty(dataFormat)){
                _pccDatetimeVariable.SetDataFormat(dataFormat);
            }
        }

        internal void BuildValue(string value)
        {
            _pccDatetimeVariable.SetValue(value);
        }


        #region Get the builded variable only when all its fields already was validated.

        internal PccDatetimeVariable GetValidatedVariable()
        {
            LoadIdentifierValidators();
            if (ParseValidators())
            {
                _pccDatetimeVariable.SetVariableAsValid();
                return _pccDatetimeVariable;
            }
            return null;
        }

        private bool ParseValidators()
        {
            var variable = _pccDatetimeVariable;
            if (IsValidIdentifierFields(variable)){
                return ParseVariableSpecificValidators();
            }
            return false;
        }

        private bool ParseVariableSpecificValidators()
        {
            var variableValidators = new List<IValidator<PccDatetimeVariable>>();
            variableValidators.Add(new DatetimeHasAValidFormatValidator());
            variableValidators.Add(new DatetimeHasAValidValueValidator());

            if (IsValidVariableSpecificFields(variableValidators, _pccDatetimeVariable)){
                return true;
            }
            return false;
        }

        #endregion
    }
}
