using MediatR;
using P1.Interview.Domain;
using PI.Interview.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PI.Interview.Services.Features.Queries
{
    public class GetSpecifiedRandomNumberOfPortfoliosQuery : IRequest<IEnumerable<Portfolio>>
    {
        public class GetSpecifiedRandomNumberOfPortfoliosQueryHandler : IRequestHandler<GetSpecifiedRandomNumberOfPortfoliosQuery, IEnumerable<Portfolio>>
        {
            private readonly IPortfolioRepository _portfolioRepository;

            public GetSpecifiedRandomNumberOfPortfoliosQueryHandler(IPortfolioRepository portfolioRepository)
            {
                _portfolioRepository = portfolioRepository;
            }
            public async Task<IEnumerable<Portfolio>> Handle(GetSpecifiedRandomNumberOfPortfoliosQuery query,
                CancellationToken cancellationToken)
            {
                var portfolios = await _portfolioRepository.GetPortfoliosForFirm();
                if (portfolios == null)
                {
                    return null;
                }
                return portfolios;
            }
        }
    }
}
