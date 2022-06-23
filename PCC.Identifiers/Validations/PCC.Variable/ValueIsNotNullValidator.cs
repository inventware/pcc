using PCC.Core.Validations;

namespace PCC.Identifiers.Validations.PCC.Variable
{
    public class ValueIsNotNullValidator : IValidator<PccVariable>
    {
        public string GetMessage()
        {
            return "The initial and final position into the code is invalid.";
        }

        public bool IsValid(PccVariable pccVariable)
        {
            if (pccVariable.InitialPositionIntoTheCode < 0)
            {
                return false;
            }

            if (pccVariable.FinalPositionIntoTheCode < 0)
            {
                return false;
            }

            if (pccVariable.InitialPositionIntoTheCode < pccVariable.FinalPositionIntoTheCode)
            {
                return false;
            }

            return true;
        }
    }
}
