using System.Collections.Generic;
using Task_3.ATS.Contract;

namespace Task_3.ATS.Billing.Interfaces
{
    public interface IBillingWriter
    {
        void WriteBilling(List<CallRecord> callRecords);
    }
}