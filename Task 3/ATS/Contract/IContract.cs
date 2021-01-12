using System;
using Task_3.ATS.Contract.ContractEntities;
using Task_3.Enum;

namespace Task_3.ATS.Contract
{
    public interface IContract
    {
        Client Client { get; }
        Terminal Terminal { get; }
        DateTime StartDate { get; }
        Tariff Tariff { get; }
        void AddCall(ActiveCall activeCall, CallType callType);
        string GetBilling(DateTime fromDate, DateTime toDate);
    }
}