using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task_3.ATS.Contract;
using Task_3.Enum;

namespace Task_3.ATS.Billing
{
    public class BillingSystem : IBillingSystem
    {
        private readonly StringBuilder _stringBuilder;
        private readonly List<ActiveCall> _callHistory;

        public BillingSystem()
        {
            _stringBuilder = new StringBuilder();
            _callHistory = new List<ActiveCall>();
        }

        public void AddCall(ActiveCall activeCall)
        {
            _callHistory.Add(activeCall);
        }

        public string GetBilling(DateTime fromDate, DateTime toDate, IContract contract)
        {
            double bill = 0;
            _stringBuilder.Clear();
            _stringBuilder.AppendLine($"Billing for {contract.Terminal.TerminalNumber}");
            var callRecords = new List<CallRecord>();
            foreach (var call in _callHistory.Where(call => fromDate <= call.StartTime && toDate >= call.StartTime))
            {
                if (call.InputNumber == contract.Terminal.TerminalNumber &&
                    call.GetCallResult() == CallResult.Successful)
                {
                    callRecords.Add(new CallRecord(call, CallType.Incoming));
                }
                else if (call.OutputNumber == contract.Terminal.TerminalNumber)
                {
                    callRecords.Add(new CallRecord(call, CallType.Outgoing));
                }
            }

            _stringBuilder.AppendLine(
                "CallType       CallDateTime            Number        CallTime      Price   CallResult");
            foreach (var call in callRecords)
            {
                _stringBuilder.AppendLine($"{call}");
                bill += call.GetPrice();
            }

            _stringBuilder.AppendLine($"Bill: {bill}");
            return _stringBuilder.ToString();
        }
    }
}