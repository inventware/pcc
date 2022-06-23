using PCC.Core.Validations;


namespace PCC.Identifiers.Validations.PCC.Identifier
{
    public class IdentifierTypeIsUndefinedValidator : IValidator<PccIdentifier>
    {
        public string GetMessage()
        {
            return "The 'Type' of identifier is undefined.";
        }

        public bool IsValid(PccIdentifier pccIdentifier)
        {
            return pccIdentifier.Type != PccIdentifierType.UNDEFINED;
        }
    }
}
