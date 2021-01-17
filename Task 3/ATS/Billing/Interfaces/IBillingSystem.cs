using System.Collections.Generic;
using Task_3.ATS.Contract;

namespace Task_3.ATS.Billing.Interfaces
{
    public interface IBillingSystem
    {
        void AddCall(Call call);
        List<CallRecord> GetBilling(BillingFilter billingFilter, IContract contract);
    }
}