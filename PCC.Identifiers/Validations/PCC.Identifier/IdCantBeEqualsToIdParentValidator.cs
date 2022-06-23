using PCC.Core.Validations;


namespace PCC.Identifiers.Validations.PCC.Identifier
{
    internal class IdCantBeEqualsToIdParentValidator : IValidator<PccIdentifier>
    {
        public string GetMessage()
        {
            return "The 'IdParent' field of identifier can't be equals to 'Id' field. The son variable should be different of " + 
                "parent variable.";
        }

        public bool IsValid(PccIdentifier pccIdentifier)
        {
            if (pccIdentifier.IdParent != null){
                return pccIdentifier.IdParent != pccIdentifier.Id;
            }
            return true;
        }
    }
}
