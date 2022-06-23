using PCC.Core.Validations;

namespace PCC.Identifiers.Validations.PCC.Identifier
{
    public class NameIsNotNullOrEmptyValidator : IValidator<PccIdentifier>
    {
        public string GetMessage()
        {
            return "The 'Name' field of identifier should'nt be a empty or null value.";
        }

        public bool IsValid(PccIdentifier pccIdentifier)
        {
            return !string.IsNullOrEmpty(pccIdentifier.Name);
        }
    }
}
