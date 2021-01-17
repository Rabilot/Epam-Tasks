using System;
using System.Collections.Generic;
using System.Text;
using Task_3.ATS.Billing.Interfaces;
using Task_3.ATS.Contract;

namespace Task_3.ATS.Billing
{
    public class BillingWriter : IBillingWriter
    {
        public void WriteBilling(List<CallRecord> callRecords)
        {
            double bill = 0;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(
                "CallType       CallDateTime            Number        CallTime      Price   CallResult");
            foreach (var callRecord in callRecords)
            {
                stringBuilder.AppendLine(callRecord.ToString());
                bill += callRecord.GetPrice();
            }

            stringBuilder.AppendLine($"Bill: {bill}");
            Console.WriteLine(stringBuilder);
        }
    }
}