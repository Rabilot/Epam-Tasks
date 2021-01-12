using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task_3.ATS;
using Task_3.ATS.Contract;

namespace Task_3
{
    public class Billing
    {
        public string GetBillingByNumber(List<ActiveCall> calls, IContract contract, DateTime fromDate, DateTime toDate)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var result = calls.Where(call => !call.IsActiveCall() &&
                                             fromDate <= call.StartTime &&
                                             toDate >= call.StartTime &&
                                             (call.OutputNumber == contract.Terminal.Number ||
                                              call.InputNumber == contract.Terminal.Number)).ToList();
            stringBuilder.AppendLine($"Billing for subscriber {contract.Terminal.Number}");
            foreach (var call in result)
            {
                Console.WriteLine((object) call.StartTime);
                if (contract.Terminal.Number == call.InputNumber || !call.IsSuccessful)
                {
                    //call.Price = 0;
                    stringBuilder.AppendLine(
                        $"Incoming call: {call.OutputNumber} {call.StartTime} {0} {call.GetCallTime()}");
                }
                else
                {
                    stringBuilder.AppendLine(
                        $"Outgoing call: {call.InputNumber} {call.StartTime} {call.Price} {call.GetCallTime()}");
                }
            }

            return stringBuilder.ToString();
        }
    }
}