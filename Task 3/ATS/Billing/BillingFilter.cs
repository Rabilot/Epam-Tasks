using System;
using Task_3.Enum;

namespace Task_3.ATS.Billing
{
    public class BillingFilter
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public CallType? Type { get; set; }
        public int? OpponentNumber { get; set; }
    }
}