using System.Collections.Generic;
using System.Linq;
using Task_3.ATS.Billing.Interfaces;
using Task_3.ATS.Contract;
using Task_3.Enum;

namespace Task_3.ATS.Billing
{
    public class BillingSystem : IBillingSystem
    {
        private readonly List<Call> _callHistory;

        public BillingSystem()
        {
            _callHistory = new List<Call>();
        }

        public void AddCall(Call call)
        {
            _callHistory.Add(call);
        }

        public List<CallRecord> GetBilling(BillingFilter billingFilter, IContract contract)
        {
            var callRecords = new List<CallRecord>();
            List<Call> filteredCalls = _callHistory;
            if (billingFilter.FromDate.HasValue && billingFilter.ToDate.HasValue)
            {
                filteredCalls = filteredCalls.Where(call =>
                    billingFilter.FromDate <= call.StartTime && billingFilter.ToDate >= call.StartTime).ToList();
            }
            if (billingFilter.Type.HasValue)
            {
                switch (billingFilter.Type)
                {
                    case CallType.Outgoing:
                        filteredCalls = filteredCalls.Where(call => call.OutputNumber == contract.Terminal.TerminalNumber).ToList();
                        break;
                    case CallType.Incoming:
                        filteredCalls = filteredCalls.Where(call => call.InputNumber == contract.Terminal.TerminalNumber).ToList();
                        break;
                }
            }

            foreach (var call in filteredCalls)
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

            if (billingFilter.OpponentNumber.HasValue)
            {
                callRecords = callRecords.Where(call => call.GetOpponentNumber() == billingFilter.OpponentNumber).ToList();
            }

            return callRecords;
        }
    }
}