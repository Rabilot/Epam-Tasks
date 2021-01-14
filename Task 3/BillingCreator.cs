using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task_3.ATS.Contract;
using Task_3.ATS.Contract.ContractEntities;

namespace Task_3
{
    public class BillingCreator
    {
        private readonly StringBuilder _stringBuilder;

        public BillingCreator()
        {
            _stringBuilder = new StringBuilder();
        }
        
        public string GetBilling(DateTime fromDate, DateTime toDate, Terminal terminal, IEnumerable<CallRecord> calls)
        {
            double bill = 0;
            _stringBuilder.Clear();
            _stringBuilder.AppendLine($"Billing for {terminal.TerminalNumber}");
            var callHistory = calls.Where(call => fromDate <= call.GetStartDateTime() 
                                                  && toDate >= call.GetStartDateTime());
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