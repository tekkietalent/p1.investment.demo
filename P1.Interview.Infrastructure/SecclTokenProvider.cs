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

        /// <summary>
        /// Using the values from the settings file, retrieve an auth token to make requests with from SECCL.
        /// </summary>
        /// <param name="httpClient">The HttpClient object used to make Http calls.</param>
        /// <returns></returns>
        public async Task<AuthToken> GetTokenAsync(HttpClient httpClient)
        {
            var authResponse = await httpClient.PostAsJsonAsync("https://pfolio-api-staging.seccl.tech/authenticate",
                                Options);

            var token = await authResponse.Content.ReadFromJsonAsync<DataRoot<AuthToken>>();

            return token.Data;
        }
    }
}
