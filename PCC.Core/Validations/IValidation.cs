
namespace PCC.Core.Validations
{
    public interface IValidator<TModel>
    {
        bool IsValid(TModel model);

        string GetMessage();
    }
}
