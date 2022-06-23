using PCC.Core.Validations;
using PCC.Identifiers.Validations.PCC.Identifier;
using System;
using System.Collections.Generic;


namespace PCC.Identifiers.Builders
{
    internal abstract class PccIdentifierBuilder<TIdentifier> : PccIdentifier
        where TIdentifier: PccIdentifier
    {
        protected List<IValidator<PccIdentifier>> _identifierValidators;
        internal abstract void Reset();

        protected void SetId(long id, ref TIdentifier identifier) 
        {
            if (identifier == null) {
                throw new ArgumentNullException("The identifier is not instanced.");
            }
            else {
                identifier.SetId(id);
            }
        }

        protected void SetIdParent(long? idParent, ref TIdentifier identifier)
        {
            identifier.SetIdParent(idParent);
        }

        protected void SetName(string name, ref TIdentifier identifier)
        {
            if (identifier == null) {
                throw new ArgumentNullException("The identifier is not instanced.");
            }
            else {
                identifier.SetName(name);
            }
        }

        protected void SetInitialPositionIntoTheCode(int initialPositionIntoTheCode, ref TIdentifier identifier) 
        {
            if (identifier == null) {
                throw new ArgumentNullException("The identifier is not instanced.");
            }
            else {
                identifier.SetInitialPositionIntoTheCode(initialPositionIntoTheCode);
            }
        }

        protected void SetFinalPositionIntoTheCode(int finalPositionIntoTheCode, ref TIdentifier identifier)
        {
            if (identifier == null) {
                throw new ArgumentNullException("The identifier is not instanced.");
            }
            else {
                identifier.SetFinalPositionIntoTheCode(finalPositionIntoTheCode);
            }
        }

        protected void SetIdentifierClass(PccIdentifierClass @class, ref TIdentifier identifier)
        {
            if (identifier == null) {
                throw new ArgumentNullException("The identifier is not instanced.");
            }
            else {
                identifier.SetClass(@class);
            }
        }

        protected void SetIdentifierScope(PccIdentifierScope scope, ref TIdentifier identifier)
        {
            if (identifier == null) {
                throw new ArgumentNullException("The identifier is not instanced.");
            }
            else {
                identifier.SetScope(scope);
            }
        }

        protected void SetIdentifierType(PccIdentifierType type, ref TIdentifier identifier)
        {
            if (identifier == null) {
                throw new ArgumentNullException("The identifier is not instanced.");
            }
            else {
                identifier.SetType(type);
            }
        }

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

        protected bool IsValidVariableSpecificFields(List<IValidator<TIdentifier>> variableValidators,
            TIdentifier variable)
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
