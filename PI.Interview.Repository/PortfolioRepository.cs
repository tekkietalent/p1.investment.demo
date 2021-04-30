using P1.Interview.Domain;
using P1.Interview.Infrastructure;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PI.Interview.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly HttpClient _httpClient;

        public PortfolioRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Portfolio[]> GetPortfoliosForFirm()
        {
            try
            {
                // this would normally come from app settings, and when hosted in Azure, key vault
                // for extra security.
                var authRequest = new AuthRequest
                {
                    FirmId = "P1IMX",
                    Id = "029B3GF",
                    Password = "7Qzq7low29"
                };

                var token = await GetAuthToken(authRequest);
                var request = BuildRequestUsingAuthToken(authRequest, token);

                var portfolioResponse = await _httpClient.SendAsync(request);

                var responseData = 
                    await portfolioResponse.Content.ReadFromJsonAsync<DataRoot<Portfolio[]>>();

                return responseData.Data;
            }
            catch (Exception ex)
            {
                //Would normally log elsewhere, and app inights would be installed on Azure
                Console.WriteLine(ex.Message);
            }

            //Would have better error handling for front end
            return Array.Empty<Portfolio>();
        }

        private static HttpRequestMessage BuildRequestUsingAuthToken(AuthRequest authRequest, DataRoot<AuthToken> token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                                new Uri($"https://pfolio-api-staging.seccl.tech/portfolio/{authRequest.FirmId}"));

            request.Headers.Add("api-token", token.Data.Token);
            return request;
        }

        private async Task<DataRoot<AuthToken>> GetAuthToken(AuthRequest authRequest)
        {
            var authResponse = await _httpClient.PostAsJsonAsync("https://pfolio-api-staging.seccl.tech/authenticate",
                                authRequest);

            var token = await authResponse.Content.ReadFromJsonAsync<DataRoot<AuthToken>>();
            return token;
        }
    }
}
