using PCC.Core.Validations;


namespace PCC.Identifiers.Validations.PCC.Identifier
{
    public class PositionIntoTheCodeIsValidValidator : IValidator<PccIdentifier>
    {
        public string GetMessage()
        {
            return "The 'initial' and 'final' position of identifier have an invalid values.";
        }

        public bool IsValid(PccIdentifier pccIdentifier)
        {
            if (pccIdentifier.InitialPositionIntoTheCode < 0){
                return false;
            }

            if (pccIdentifier.FinalPositionIntoTheCode < 0){
                return false;
            }

            if (pccIdentifier.InitialPositionIntoTheCode > pccIdentifier.FinalPositionIntoTheCode){
                return false;
            }

            return true;
        }
    }
}
