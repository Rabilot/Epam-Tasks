using System;
using Task_3.ATS.Contract;

namespace Task_3.ATS.Billing
{
    public interface IBillingSystem
    {
        void AddCall(ActiveCall activeCall);
        string GetBilling(DateTime fromDate, DateTime toDate, IContract contract);
    }
}