using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1.Interview.Domain
{
    public class PortfolioAggregate : BaseEntity
    {
        public List<Portfolio> Portfolios { get; set; }

        public decimal AggregateValue { get; set; }
    }
}
