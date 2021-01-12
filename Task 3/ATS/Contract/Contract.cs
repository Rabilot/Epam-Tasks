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
        private readonly StringBuilder _stringBuilder;
        public Client Client { get; }
        public Terminal Terminal { get; }
        public DateTime StartDate { get; }
        public Tariff Tariff { get; }
        private readonly List<CallHistory> _calls;

        public Contract(string name, int number, Tariff tariff)
        {
            _stringBuilder = new StringBuilder();
            Client = new Client(name);
            Terminal = new Terminal(number);
            StartDate = DateTime.Now;
            Tariff = tariff;
            _calls = new List<CallHistory>();
        }

        public void AddCall(ActiveCall activeCall, CallType callType)
        {
            _calls.Add(new CallHistory(activeCall, callType));
        }

        public string GetBilling(DateTime fromDate, DateTime toDate)
        {
            double bill = 0;
            _stringBuilder.Clear();
            _stringBuilder.AppendLine($"Billing for {Terminal.Number}");
            var callHistory = _calls.Where(call => fromDate <= call.GetStartTime() &&
                                                   toDate >= call.GetStartTime());
            foreach (var call in callHistory)
            {
                _stringBuilder.AppendLine($"{call}");
                bill += call.GetPrice();
            }

            _stringBuilder.AppendLine($"Bill: {bill}");
            return _stringBuilder.ToString();
        }
    }
}