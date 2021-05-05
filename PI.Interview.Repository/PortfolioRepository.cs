using P1.Interview.Domain;
using P1.Interview.Infrastructure;
using P1.Interview.Infrastructure.Services;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PI.Interview.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ISecclHttpClient _httpClient;

        public PortfolioRepository(ISecclHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Portfolio[]> GetPortfoliosForFirm()
        {
            try
            {
                var response = await _httpClient.GetEntityData<Portfolio[]>("Portfolio");

                return response;
            }
            catch (Exception ex)
            {
                //Would normally log elsewhere, and app inights would be installed on Azure
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
