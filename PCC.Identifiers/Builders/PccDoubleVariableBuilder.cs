using PCC.Core.Validations;
using PCC.Identifiers.Validations.PCC.Variable.Double;
using System.Collections.Generic;


namespace PCC.Identifiers.Builders
{
    internal class PccDoubleVariableBuilder : PccIdentifierBuilder<PccDoubleVariable>
    {
        private PccDoubleVariable _pccDoubleVariable;

        public PccDoubleVariable GetVariable 
        { 
            get => _pccDoubleVariable; 
            protected set => _pccDoubleVariable = value; 
        }


        internal override void Reset() 
        {
            _pccDoubleVariable = new PccDoubleVariable();
        }

        internal void BuildId(long id)
        {
            base.SetId(id, ref _pccDoubleVariable);
        }

        internal void BuildIdParent(long? idParent)
        {
            base.SetIdParent(idParent, ref _pccDoubleVariable);
        }

        internal void BuildName(string name)
        {
            base.SetName(name, ref _pccDoubleVariable);
        }

        internal void BuildInitialPositionIntoTheCode(int initialPositionIntoTheCode)
        {
            base.SetInitialPositionIntoTheCode(initialPositionIntoTheCode, ref _pccDoubleVariable);
        }

        internal void BuildFinalPositionIntoTheCode(int finalPositionIntoTheCode)
        {
            base.SetFinalPositionIntoTheCode(finalPositionIntoTheCode, ref _pccDoubleVariable);
        }

        internal void BuildIdentifierScope(PccIdentifierScope pccIdentifierScope)
        {
            SetIdentifierScope(pccIdentifierScope, ref _pccDoubleVariable);
        }

        internal void BuildIdentifierType()
        {
            _pccDoubleVariable.SetType(PccIdentifierType.DOUBLE);
        }

        internal void BuildIdentifierClass()
        {
            _pccDoubleVariable.SetClass(PccIdentifierClass.VARIABLE);
        }

        internal void BuildValue(string value)
        {
            _pccDoubleVariable.SetValue(value);
        }


        #region Get the builded variable only when all its fields already was validated.

        internal PccDoubleVariable GetValidatedVariable()
        {
            LoadIdentifierValidators();
            if (ParseValidators())
            {
                _pccDoubleVariable.SetVariableAsValid();
                return _pccDoubleVariable;
            }
            return null;
        }

        private bool ParseValidators()
        {
            var variable = _pccDoubleVariable;
            if (IsValidIdentifierFields(variable)){
                return ParseVariableSpecificValidators();
            }
            return false;
        }

        private bool ParseVariableSpecificValidators()
        {
            var variableValidators = new List<IValidator<PccDoubleVariable>>();
            variableValidators.Add(new ValueIsntConversibleToDoubleValuesValidator());
            variableValidators.Add(new InvalidCharactersForDoubleNumbersValidator());

            if (IsValidVariableSpecificFields(variableValidators, _pccDoubleVariable)){
                return true;
            }
            return false;
        }

        #endregion
    }
}
