using System;

namespace P1.Interview.Domain
{
    public class Portfolio
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Currency { get; set; }

        public double CurrencyValue { get; set; }

        public double UninvestedCash { get; set; }

        public double Growth { get; set; }

        public double GrowthPercent { get; set; }
    }
}
