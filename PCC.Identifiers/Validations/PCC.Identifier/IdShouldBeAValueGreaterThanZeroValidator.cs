using PCC.Core.Validations;


namespace PCC.Identifiers.Validations.PCC.Identifier
{
    internal class IdShouldBeAValueGreaterThanZeroValidator : IValidator<PccIdentifier>
    {
        public string GetMessage()
        {
            return "The 'Id' field of identifier should be a value greater than zero.";
        }

        public bool IsValid(PccIdentifier pccIdentifier)
        {
            return pccIdentifier.Id >= 0;
        }
    }
}
