using MediatR;
using P1.Interview.Domain;
using PI.Interview.Repository;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PI.Interview.Services.Features.Queries
{
    public class GetAllFirmPortfoliosQuery : IRequest<IEnumerable<Portfolio>>
    {
        public class GetAllFirmPortfoliosQueryHandler : IRequestHandler<GetAllFirmPortfoliosQuery, IEnumerable<Portfolio>>
        {
            private readonly IPortfolioRepository _portfolioRepository;

            public GetAllFirmPortfoliosQueryHandler(IPortfolioRepository portfolioRepository)
            {
                _portfolioRepository = portfolioRepository;
            }
            public async Task<IEnumerable<Portfolio>> Handle(GetAllFirmPortfoliosQuery query,
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
