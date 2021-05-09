using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace P1.Interview.Infrastructure.Services
{
    public class SecclHttpClient : ISecclHttpClient
    {
        private readonly ISecclTokenProvider _secclTokenProvider;
        private readonly HttpClient _httpClient;

        public SecclHttpClient(ISecclTokenProvider secclTokenProvider,
            HttpClient httpClient)
        {
            _secclTokenProvider = secclTokenProvider;
            _httpClient = httpClient;
        }

        /// <summary>
        /// A generic method to return a type T from the API service.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityName"></param>
        /// <returns></returns>
        public async Task<T> GetEntityData<T>(string entityName)
        {
            var token = await _secclTokenProvider.GetTokenAsync(_httpClient);

            var request = BuildRequestUsingAuthToken(_secclTokenProvider.Options, token, entityName.ToLowerInvariant());

            var portfolioResponse = await _httpClient.SendAsync(request);

            var responseData =
                await portfolioResponse.Content.ReadFromJsonAsync<DataRoot<T>>();

            return responseData.Data;
        }

        /// <summary>
        /// Construct the Http Request with the necessary token for authentication with SECCL.
        /// </summary>
        /// <param name="authRequest"></param>
        /// <param name="token"></param>
        /// <param name="entityName"></param>
        /// <returns></returns>
        private static HttpRequestMessage BuildRequestUsingAuthToken(AuthRequest authRequest, 
            AuthToken token, 
            string entityName)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                                $"{entityName}/{authRequest.FirmId}");

            request.Headers.Add("api-token", token.Token);
            return request;
        }
    }
}
