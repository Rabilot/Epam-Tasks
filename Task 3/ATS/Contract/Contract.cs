using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task_3.ATS.Contract.ContractEntities;
using Task_3.Enum;

namespace Task_3.ATS.Contract
{
    public class Contract : IContract
    {
        public Client Client { get; }
        public Terminal Terminal { get; }
        public DateTime StartDate { get; }
        public Tariff Tariff { get; }
        
        private readonly List<CallRecord> _calls;

        public Contract(string name, int number, Tariff tariff)
        {
            Client = new Client(name);
            Terminal = new Terminal(number);
            StartDate = DateTime.Now;
            Tariff = tariff;
            _calls = new List<CallRecord>();
        }

        public void AddCall(ActiveCall activeCall, CallType callType)
        {
            _calls.Add(new CallRecord(activeCall, callType));
        }

        public string GetBilling(DateTime fromDate, DateTime toDate)
        {
            return new BillingCreator().GetBilling(fromDate, toDate, Terminal, _calls);
        }
    }
}