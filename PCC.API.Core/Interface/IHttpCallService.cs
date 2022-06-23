using System.Threading.Tasks;


namespace PCC.API.Core.Interface
{
    public interface IHttpCallService
    {
        Task<T> GetData<T>();
    }
}
