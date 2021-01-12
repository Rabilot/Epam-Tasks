using System;
using System.Threading;
using Task_3.ATS;
using Task_3.ATS.Contract.ContractEntities;

namespace Task_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IATS ats = new ATS.ATS();
            ats.AddContract("Nick", new Tariff(0.1));
            ats.AddContract("Mike", new Tariff(0.1));
            ats.AddContract("Alex", new Tariff(0.1));

            ats.FindContractByIndex(0).Terminal.OutCall(ats.FindContractByIndex(1).Terminal.Number);
            ats.FindContractByIndex(1).Terminal.AnswerCall();
            ats.FindContractByIndex(2).Terminal.OutCall(ats.FindContractByIndex(0).Terminal.Number);
            Thread.Sleep(1000);
            ats.FindContractByIndex(1).Terminal.EndCall();

            Console.WriteLine(ats.FindContractByIndex(0)
                .GetBilling(ats.FindContractByIndex(0).StartDate, DateTime.Now));
            Console.WriteLine(ats.FindContractByIndex(1)
                .GetBilling(ats.FindContractByIndex(1).StartDate, DateTime.Now));
            Console.WriteLine(ats.FindContractByIndex(2)
                .GetBilling(ats.FindContractByIndex(2).StartDate, DateTime.Now));

            Console.WriteLine(ats.FindContractByIndex(0).Terminal.GetPortState());
            Console.WriteLine(ats.FindContractByIndex(1).Terminal.GetPortState());
            Console.WriteLine(ats.FindContractByIndex(2).Terminal.GetPortState());
            Console.Beep();
        }
    }
}