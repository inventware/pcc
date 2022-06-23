using PCC.Identifiers.Builders;
using System;


namespace PCC.Identifiers.Directors
{
    internal class PccBooleanVariableDirector: PccAbstractDirector<PccBooleanVariable>
    {
        internal PccBooleanVariableBuilder _variableBuilder;

        public PccBooleanVariableDirector()
        {
            _variableBuilder = new PccBooleanVariableBuilder();
        }

        internal PccBooleanVariable Build(long id, long? idParent, string name, int initialPositionIntoTheCode,
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
