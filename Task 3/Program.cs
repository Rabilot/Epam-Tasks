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
            ats.FindContractByIndex(1).Terminal.DisconnectPort();

            Console.WriteLine(ats.GetBilling(ats.FindContractByIndex(0).StartDate, DateTime.Now,
                ats.FindContractByIndex(0)));
            Console.WriteLine(ats.GetBilling(ats.FindContractByIndex(1).StartDate, DateTime.Now,
                ats.FindContractByIndex(1)));
            Console.WriteLine(ats.GetBilling(ats.FindContractByIndex(2).StartDate, DateTime.Now,
                ats.FindContractByIndex(2)));


            Console.WriteLine(ats.FindContractByIndex(0).Terminal.Port.GetPortState());
            Console.WriteLine(ats.FindContractByIndex(1).Terminal.Port.GetPortState());
            Console.WriteLine(ats.FindContractByIndex(2).Terminal.Port.GetPortState());
            Console.Beep();
        }
    }
}