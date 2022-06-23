using PCC.Identifiers.Builders;
using System;


namespace PCC.Identifiers.Directors
{
    internal class PccIntegerVariableDirector: PccAbstractDirector<PccIntegerVariable>
    {
        internal PccIntegerVariableBuilder _variableBuilder;

        public PccIntegerVariableDirector()
        {
            _variableBuilder = new PccIntegerVariableBuilder();
        }

        internal PccIntegerVariable Build(long id, long? idParent, string name, int initialPositionIntoTheCode,
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
