using P1.Interview.Domain;
using System.Threading.Tasks;

namespace PI.Interview.Repository
{
    public interface IPortfolioRepository
    {
        Task<Portfolio[]> GetPortfoliosForFirm();
    }
}
