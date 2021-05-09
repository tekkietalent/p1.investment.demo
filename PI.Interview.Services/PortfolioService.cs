using P1.Interview.Domain;
using PI.Interview.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PI.Interview.Services
{
    public class PortfolioService : IPortfolioService
    {
        IPortfolioRepository _portfolioRepository { get; }

        public PortfolioService(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        /// <summary>
        /// Returns a list of N portfolios in random order from the Repository.
        /// </summary>
        /// <param name="numberToRetrieve">Number of portfolios to retrieve</param>
        /// <returns></returns>
        public async Task<PortfolioAggregate> GetNRandomPortfolios(int numberToRetrieve)
        {
            var listOfPortfolios = await _portfolioRepository.GetPortfoliosForFirm();

            var listOfNPortfolios = listOfPortfolios
                .OrderBy(x => Guid.NewGuid())
                .Take(numberToRetrieve)
                .ToList();

            var sumOfPortfolioValues = listOfNPortfolios.Sum(p => p.CurrentValue);

            return new PortfolioAggregate
            {
                Portfolios = listOfNPortfolios,
                AggregateValue = sumOfPortfolioValues
            };
        }
    }
}
