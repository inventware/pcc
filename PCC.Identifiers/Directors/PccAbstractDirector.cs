using PCC.Core.Validations;
using PCC.Identifiers.Validations.PCC.Identifier;
using System;
using System.Collections.Generic;


namespace PCC.Identifiers.Directors
{
    internal abstract class PccAbstractDirector<TVariable>
    {
        protected List<IValidator<PccIdentifier>> _identifierValidators;

        protected void LoadIdentifierValidators()
        {
            _identifierValidators = new List<IValidator<PccIdentifier>>();
            _identifierValidators.Add(new IdShouldBeAValueGreaterThanZeroValidator());
            _identifierValidators.Add(new IdParentShouldBeAValueGreaterThanZeroValidator());
            _identifierValidators.Add(new IdCantBeEqualsToIdParentValidator());
            _identifierValidators.Add(new NameIsNotNullOrEmptyValidator());
            _identifierValidators.Add(new PositionIntoTheCodeIsValidValidator());
            _identifierValidators.Add(new IdentifierScopeIsUndefinedValidator());
            _identifierValidators.Add(new IdentifierTypeIsUndefinedValidator());
        }

        protected bool IsValidIdentifierFields(PccIdentifier identifier)
        {
            foreach (var validator in _identifierValidators)
            {
                if (!validator.IsValid(identifier)){
                    throw new ArgumentOutOfRangeException(validator.GetMessage(), new Exception());
                }
            }
            return true;
        }

        protected bool IsValidVariableSpecificFields(List<IValidator<TVariable>> variableValidators,
            TVariable variable)
        {
            foreach (var validator in variableValidators)
            {
                if (!validator.IsValid(variable)){
                    throw new ArgumentOutOfRangeException(validator.GetMessage(), new Exception());
                }
            }
            return true;
        }
    }
}
