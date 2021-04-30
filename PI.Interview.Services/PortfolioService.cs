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

        public async Task<PortfolioAggregate> GetThreeRandomPortfolios()
        {
            var listOfPortfolios = await _portfolioRepository.GetPortfoliosForFirm();

            var listOfThreePortfolios = listOfPortfolios
                .OrderBy(x => Guid.NewGuid())
                .Take(3)
                .ToList();

            var sumOfPortfolioValues = listOfThreePortfolios.Sum(p => p.CurrentValue);

            return new PortfolioAggregate
            {
                Portfolios = listOfThreePortfolios,
                AggregateValue = sumOfPortfolioValues
            };
        }
    }
}
