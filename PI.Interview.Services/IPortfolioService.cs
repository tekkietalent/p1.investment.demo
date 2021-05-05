using P1.Interview.Domain;
using System.Threading.Tasks;

namespace PI.Interview.Services
{
    public interface IPortfolioService
    {
        public Task<PortfolioAggregate> GetNRandomPortfolios(int numberToRetrieve);
    }
}
