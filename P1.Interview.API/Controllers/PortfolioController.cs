using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PI.Interview.Services;
using P1.Interview.Domain;

namespace P1.Interview.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        /// <summary>
        /// Gets N random firm related portfolios.
        /// </summary>
        /// <param name="sampleSize"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRandomPortfolios")]
        public async Task<PortfolioAggregate> GetRandomPortfoliosAsync(int sampleSize)
        {
            var result = await _portfolioService.GetNRandomPortfolios(sampleSize);

            return result;
        }
    }
}
