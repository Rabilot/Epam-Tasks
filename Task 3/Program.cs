using System;
using Task_3.ATS_entities;

namespace Task_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ATS ats = new ATS();
            Tariff tariff = new Tariff(0.1);
            ats.AddContract(new Contract(new Client("Nick"), new Terminal(265874), tariff));
            ats.AddContract(new Contract(new Client("Mike"), new Terminal(578854), tariff));
            ats.AddContract(new Contract(new Client("Alex"), new Terminal(986245), tariff));

            foreach (var contract in ats.Contracts)
            {
                contract.Terminal.OutCallEvent += ats.CallOutHandler;
                contract.Terminal.EndCallEvent += ats.EndCallHandler;
            }
            
            ats.Contracts[0].Terminal.OutCall(ats.Contracts[1].Terminal.Number);
            ats.Contracts[2].Terminal.OutCall(ats.Contracts[0].Terminal.Number);
            System.Threading.Thread.Sleep(1000);
            ats.Contracts[1].Terminal.EndCall();

            Billing billing = new Billing();
            Console.WriteLine(billing.GetBillingByNumber(ats.Calls, ats.Contracts[1], ats.Contracts[1].StartDate,
                DateTime.Now));
            Console.WriteLine(billing.GetBillingByNumber(ats.Calls, ats.Contracts[0], ats.Contracts[0].StartDate,
                DateTime.Now));

            Console.WriteLine(ats.Contracts[0].Terminal.GetPortState());
            Console.WriteLine(ats.Contracts[1].Terminal.GetPortState());
            Console.WriteLine(ats.Contracts[2].Terminal.GetPortState());
            Console.Beep();
            foreach (var contract in ats.Contracts)
            {
                contract.Terminal.OutCallEvent -= ats.CallOutHandler;
                contract.Terminal.EndCallEvent -= ats.EndCallHandler;
            }
        }
    }
}