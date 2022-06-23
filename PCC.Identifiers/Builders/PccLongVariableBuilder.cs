using System;

namespace PCC.Identifiers.Builders
{
    internal class PccLongVariableBuilder : PccIdentifierBuilder<PccLongVariable>
    {
        private PccLongVariable _pccLongVariable;

        public PccLongVariable GetVariable 
        { 
            get => _pccLongVariable; 
            protected set => _pccLongVariable = value; 
        }

        #region Build Variable

        internal override void Reset() 
        {
            _pccLongVariable = new PccLongVariable();
        }

        internal void BuildId(long id)
        {
            base.SetId(id, ref _pccLongVariable);
        }

        internal void BuildIdParent(long? idParent)
        {
            base.SetIdParent(idParent, ref _pccLongVariable);
        }

        internal void BuildName(string name)
        {
            base.SetName(name, ref _pccLongVariable);
        }

        internal void BuildInitialPositionIntoTheCode(int initialPositionIntoTheCode)
        {
            base.SetInitialPositionIntoTheCode(initialPositionIntoTheCode, ref _pccLongVariable);
        }

        internal void BuildFinalPositionIntoTheCode(int finalPositionIntoTheCode)
        {
            base.SetFinalPositionIntoTheCode(finalPositionIntoTheCode, ref _pccLongVariable);
        }

        internal void BuildIdentifierScope(PccIdentifierScope pccIdentifierScope)
        {
            SetIdentifierScope(pccIdentifierScope, ref _pccLongVariable);
        }

        internal void BuildIdentifierType()
        {
            _pccLongVariable.SetType(PccIdentifierType.LONG);
        }

        internal void BuildIdentifierClass()
        {
            _pccLongVariable.SetClass(PccIdentifierClass.VARIABLE);
        }

        internal void SetValue(string value)
        {
            _pccLongVariable.SetValue(value);
        }

        #endregion
    }
}
