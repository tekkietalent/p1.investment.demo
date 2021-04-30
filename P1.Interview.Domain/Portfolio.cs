using System;

namespace P1.Interview.Domain
{
    public class Portfolio
    {
        public string Id { get; set; }
        public string FirmId { get; set; }
        public string Status { get; set; }
        public int Accounts { get; set; }

        public string Name { get; set; }

        public string Currency { get; set; }

        public decimal CurrentValue { get; set; }

        public decimal UninvestedCash { get; set; }

        public decimal Growth { get; set; }

        public decimal GrowthPercent { get; set; }
    }
}
