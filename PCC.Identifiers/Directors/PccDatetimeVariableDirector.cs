using PCC.Identifiers.Builders;
using System;


namespace PCC.Identifiers.Directors
{
    internal class PccDatetimeVariableDirector: PccAbstractDirector<PccDatetimeVariable>
    {
        internal PccDatetimeVariableBuilder _variableBuilder;

        public PccDatetimeVariableDirector()
        {
            _variableBuilder = new PccDatetimeVariableBuilder();
        }

        internal PccDatetimeVariable Build(long id, long? idParent, string name, int initialPositionIntoTheCode,
            int finalPositionIntoTheCode, PccIdentifierScope scope, string value, string dataFormat)
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
                _variableBuilder.BuildDataFormat(dataFormat);
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
