using PCC.Core.Validations;


namespace PCC.Identifiers.Validations.PCC.Identifier
{
    public class IdentifierScopeIsUndefinedValidator : IValidator<PccIdentifier>
    {
        public string GetMessage()
        {
            return "The 'Scope' of identifier is undefined.";
        }

        public bool IsValid(PccIdentifier pccIdentifier)
        {
            return pccIdentifier.Scope != PccIdentifierScope.UNDEFINED;
        }
    }
}
