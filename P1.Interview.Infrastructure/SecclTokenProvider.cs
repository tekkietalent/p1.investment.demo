using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace P1.Interview.Infrastructure
{
    public class SecclTokenProvider : ISecclTokenProvider
    {
        public AuthRequest Options { get; set; }

        public SecclTokenProvider(AuthRequest options)
        {
            Options = options;
        }

        public async Task<AuthToken> GetTokenAsync(HttpClient httpClient)
        {
            var authResponse = await httpClient.PostAsJsonAsync("https://pfolio-api-staging.seccl.tech/authenticate",
                                Options);

            var token = await authResponse.Content.ReadFromJsonAsync<DataRoot<AuthToken>>();

            return token.Data;
        }
    }
}
