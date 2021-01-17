using System;
using System.Threading;
using Task_3.ATS;
using Task_3.ATS.Billing;
using Task_3.ATS.Billing.Interfaces;
using Task_3.ATS.Contract.ContractEntities;
using Task_3.Enum;

namespace Task_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IATS ats = new ATS.ATS(new BillingSystem());
            ats.AddContract("Nick", new Tariff());
            ats.AddContract("Mike", new Tariff());
            ats.AddContract("Alex", new Tariff());

            Console.WriteLine(
                $"Абонент {ats.FindContractByIndex(0).Terminal.TerminalNumber} звонит абоненту {ats.FindContractByIndex(1).Terminal.TerminalNumber}");
            ats.FindContractByIndex(0).Terminal.OutCall(ats.FindContractByIndex(1).Terminal.TerminalNumber);
            Console.WriteLine($"Абонент {ats.FindContractByIndex(1).Terminal.TerminalNumber} ответил");
            ats.FindContractByIndex(1).Terminal.AnswerCall();
            Console.WriteLine(
                $"Абонент {ats.FindContractByIndex(2).Terminal.TerminalNumber} звонит абоненту {ats.FindContractByIndex(0).Terminal.TerminalNumber}");
            ats.FindContractByIndex(2).Terminal.OutCall(ats.FindContractByIndex(0).Terminal.TerminalNumber);
            Thread.Sleep(1000);
            ats.FindContractByIndex(1).Terminal.EndCall();
            Console.WriteLine(
                $"Абонент {ats.FindContractByIndex(1).Terminal.TerminalNumber} звонит абоненту {ats.FindContractByIndex(2).Terminal.TerminalNumber}");
            ats.FindContractByIndex(1).Terminal.OutCall(ats.FindContractByIndex(2).Terminal.TerminalNumber);
            Console.WriteLine($"Абонент {ats.FindContractByIndex(2).Terminal.TerminalNumber} ответил");
            ats.FindContractByIndex(2).Terminal.AnswerCall();
            ats.FindContractByIndex(1).Terminal.Port.Disconnect();
            ats.FindContractByIndex(1).Terminal.Port.Connect();

            IBillingWriter billingWriter = new BillingWriter();
            Console.WriteLine($"Billing for {ats.FindContractByIndex(0).Terminal.TerminalNumber}");
            billingWriter.WriteBilling(ats.GetBilling(new BillingFilter(), ats.FindContractByIndex(0)));
            Console.WriteLine($"Billing for {ats.FindContractByIndex(1).Terminal.TerminalNumber}");
            billingWriter.WriteBilling(ats.GetBilling(new BillingFilter(), ats.FindContractByIndex(1)));
            Console.WriteLine($"Billing for {ats.FindContractByIndex(2).Terminal.TerminalNumber}");
            billingWriter.WriteBilling(ats.GetBilling(new BillingFilter(), ats.FindContractByIndex(2)));
            Console.WriteLine($"Billing for {ats.FindContractByIndex(2).Terminal.TerminalNumber}");
            billingWriter.WriteBilling(ats.GetBilling(new BillingFilter {Type = CallType.Outgoing},
                ats.FindContractByIndex(2)));

            Console.WriteLine("PortHistory:");
            foreach (var portRecord in ats.GetPortsHistory())
            {
                Console.WriteLine(portRecord);
            }

            Console.Beep();
        }
    }
}