using PCC.Core.Validations;
using PCC.Identifiers.Builders;
using PCC.Identifiers.Directors;
using PCC.Identifiers.Validations.PCC.Variable.Integer;
using System;
using System.Collections.Generic;


namespace PCC.Identifiers.Directors
{
    internal class PccLongVariableDirector: PccAbstractDirector<PccLongVariable>
    {
        private PccLongVariableBuilder _variableBuilder;

        internal PccLongVariableDirector()
        {
            _variableBuilder = new PccLongVariableBuilder();
        }

        internal PccLongVariable Build(long id, long? idParent, string name, int initialPositionIntoTheCode,
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

                return GetVariable(value);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        private PccLongVariable GetVariable(string value)
        {
            LoadIdentifierValidators();
            if (ParseValidators(value)){
                return _variableBuilder.GetVariable;
            }
            return null;
        }

        private bool ParseValidators(string value)
        {
            var variable = _variableBuilder.GetVariable;
            if (IsValidIdentifierFields(variable))
            {
                variable.SetValue(value);
                return ParseVariableSpecificValidators();
            }
            return false;
        }

        private bool ParseVariableSpecificValidators()
        {
            var variableValidators = new List<IValidator<PccLongVariable>>();
            variableValidators.Add(new LongValuesOutOfRangeAllowedValuesValidator());

            if (IsValidVariableSpecificFields(variableValidators, _variableBuilder.GetVariable)){
                return true;
            }
            return false;
        }
    }
}
