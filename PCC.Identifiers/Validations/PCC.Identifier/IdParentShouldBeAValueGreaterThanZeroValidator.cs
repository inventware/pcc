using PCC.Core.Validations;


namespace PCC.Identifiers.Validations.PCC.Identifier
{
    internal class IdParentShouldBeAValueGreaterThanZeroValidator : IValidator<PccIdentifier>
    {
        public string GetMessage()
        {
            return "If 'IdParent' field of identifier is not null, it should be a value greater than zero.";
        }

        public bool IsValid(PccIdentifier pccIdentifier)
        {
            if (pccIdentifier.IdParent != null){
                return pccIdentifier.IdParent >= 0;
            }
            return true;
        }
    }
}
