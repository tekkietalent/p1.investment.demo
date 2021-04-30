using P1.Interview.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PI.Interview.Repository
{
    public interface IPortfolioRepository
    {
        Task<Portfolio[]> GetPortfoliosForFirm();
    }
}
