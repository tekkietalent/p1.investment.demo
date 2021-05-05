using System.Net.Http;
using System.Threading.Tasks;

namespace P1.Interview.Infrastructure
{
    public interface ISecclTokenProvider
    {
        AuthRequest Options { get; set; }

        Task<AuthToken> GetTokenAsync(HttpClient httpClient);
    }
}
