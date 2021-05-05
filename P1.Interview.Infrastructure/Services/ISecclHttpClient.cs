using System.Threading.Tasks;

namespace P1.Interview.Infrastructure.Services
{
    public interface ISecclHttpClient
    {
        Task<T> GetEntityData<T>(string entityName);
    }
}
