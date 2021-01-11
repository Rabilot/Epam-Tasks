using System;
using Task_3.ATS_entities;

namespace Task_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ATS ats = new ATS();
            ats.AddContract(new Contract(new Client("Nick"), new Terminal(265874, 1001), new Tariff(0.1)));
            ats.AddContract(new Contract(new Client("Mike"), new Terminal(578854, 1002), new Tariff(0.1)));
            ats.AddContract(new Contract(new Client("Alex"), new Terminal(986245, 1001), new Tariff(0.1)));

            foreach (var contract in ats.Contracts)
            {
                contract.Terminal.OutCallEvent += ats.CallOutHandler;
                contract.Terminal.EndCallEvent += ats.EndCallHandler;
                contract.Terminal.ConnectPortEvent += ats.ConnectPortHandler;
                contract.Terminal.DisconnectPortEvent += ats.DisconnectPortHandler;
                contract.Terminal.AnswerCallEvent += ats.AnswerCallHandler;
            }
            
            ats.FindContractByIndex(0).Terminal.OutCall(ats.FindContractByIndex(1).Terminal.Number);
            ats.FindContractByIndex(1).Terminal.AnswerCall();
            ats.FindContractByIndex(2).Terminal.OutCall(ats.FindContractByIndex(0).Terminal.Number);
            System.Threading.Thread.Sleep(1000);
            ats.FindContractByIndex(1).Terminal.EndCall();

            Billing billing = new Billing();
            Console.WriteLine(billing.GetBillingByNumber(ats.Calls, ats.FindContractByIndex(1), ats.FindContractByIndex(1).StartDate,
                DateTime.Now));
            Console.WriteLine(billing.GetBillingByNumber(ats.Calls, ats.FindContractByIndex(0), ats.FindContractByIndex(0).StartDate,
                DateTime.Now));

            Console.WriteLine(ats.FindContractByIndex(0).Terminal.GetPortState());
            Console.WriteLine(ats.FindContractByIndex(1).Terminal.GetPortState());
            Console.WriteLine(ats.FindContractByIndex(2).Terminal.GetPortState());
            Console.Beep();
            foreach (var contract in ats.Contracts)
            {
                contract.Terminal.OutCallEvent -= ats.CallOutHandler;
                contract.Terminal.EndCallEvent -= ats.EndCallHandler;
            }
        }
    }
}