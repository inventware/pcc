using PCC.Identifiers.Builders;
using System;


namespace PCC.Identifiers.Directors
{
    internal class PccStringVariableDirector: PccAbstractDirector<PccStringVariable>
    {
        internal PccStringVariableBuilder _variableBuilder;

        public PccStringVariableDirector()
        {
            _variableBuilder = new PccStringVariableBuilder();
        }

        internal PccStringVariable Build(long id, long? idParent, string name, int initialPositionIntoTheCode,
            int finalPositionIntoTheCode, PccIdentifierScope scope, string value)
        {
            try
            {
                _variableBuilder.Reset();
                _variableBuilder.BuildId(id);
                _variableBuilder.BuildIdParent(idParent);
                _variableBuilder.BuildName(name);
                _variableBuilder.BuildInitialPositionIntoTheCode(initialPositionIntoTheCode);
                _variableBuilder.BuildFinalPositionIntoTheCode(finalPositionIntoTheCode);
                _variableBuilder.BuildIdentifierScope(scope);
                _variableBuilder.BuildIdentifierType();
                _variableBuilder.BuildIdentifierClass();
                _variableBuilder.BuildValue(value);

                return _variableBuilder.GetValidatedVariable();
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
