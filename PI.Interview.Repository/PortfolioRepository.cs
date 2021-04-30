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
            _httpClient= httpClient;
        }

        public async Task<Portfolio[]> GetPortfoliosForFirm()
        {
            try
            {
                var authRequest = new AuthRequest
                {
                    FirmId = "P1IMX",
                    Id = "029B3GF",
                    Password = "7Qzq7low29"
                };

                var authResponse = await _httpClient.PostAsJsonAsync("https://pfolio-api-staging.seccl.tech/authenticate",
                    authRequest);

                var token = await authResponse.Content.ReadFromJsonAsync<DataRoot<AuthToken>>();

                var request = new HttpRequestMessage(HttpMethod.Get,
                    new Uri($"https://pfolio-api-staging.seccl.tech/portfolio/{authRequest.FirmId}"));

                request.Headers.Add("api-token", token.Data.Token);

                var portfolioResponse = await _httpClient.SendAsync(request);

                var stringData = await portfolioResponse.Content.ReadAsStringAsync();
                var responeData = await portfolioResponse.Content.ReadFromJsonAsync<DataRoot<Portfolio[]>>();

                var portfolios = responeData.Data;

                return portfolios;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Array.Empty<Portfolio>();
        }
    }
}
