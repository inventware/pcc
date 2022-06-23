using PCC.Core.Validations;
using System.Collections.Generic;


namespace PCC.Identifiers.Builders
{
    internal class PccStringVariableBuilder : PccIdentifierBuilder<PccStringVariable>
    {
        private PccStringVariable _pccStringVariable;

        internal override void Reset() 
        {
            _pccStringVariable = new PccStringVariable();
        }

        internal void BuildId(long id)
        {
            base.SetId(id, ref _pccStringVariable);
        }

        internal void BuildIdParent(long? idParent)
        {
            base.SetIdParent(idParent, ref _pccStringVariable);
        }

        internal void BuildName(string name)
        {
            base.SetName(name, ref _pccStringVariable);
        }

        internal void BuildInitialPositionIntoTheCode(int initialPositionIntoTheCode)
        {
            base.SetInitialPositionIntoTheCode(initialPositionIntoTheCode, ref _pccStringVariable);
        }

        internal void BuildFinalPositionIntoTheCode(int finalPositionIntoTheCode)
        {
            base.SetFinalPositionIntoTheCode(finalPositionIntoTheCode, ref _pccStringVariable);
        }

        internal void BuildIdentifierScope(PccIdentifierScope pccIdentifierScope)
        {
            SetIdentifierScope(pccIdentifierScope, ref _pccStringVariable);
        }

        internal void BuildIdentifierType()
        {
            _pccStringVariable.SetType(PccIdentifierType.STRING);
        }

        internal void BuildIdentifierClass()
        {
            _pccStringVariable.SetClass(PccIdentifierClass.VARIABLE);
        }

        internal void BuildValue(string value)
        {
            _pccStringVariable.SetValue(value);
        }


        #region Get the builded variable only when all its fields already was validated.

        internal PccStringVariable GetValidatedVariable()
        {
            LoadIdentifierValidators();
            if (ParseValidators())
            {
                _pccStringVariable.SetVariableAsValid();
                return _pccStringVariable;
            }
            return null;
        }

        private bool ParseValidators()
        {
            var variable = _pccStringVariable;
            if (IsValidIdentifierFields(variable)){
                return ParseVariableSpecificValidators();
            }
            return false;
        }

        private bool ParseVariableSpecificValidators()
        {
            var variableValidators = new List<IValidator<PccStringVariable>>();

            if (IsValidVariableSpecificFields(variableValidators, _pccStringVariable)){
                return true;
            }
            return false;
        }

        #endregion
    }
}
